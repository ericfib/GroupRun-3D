using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject player, finishObject;
    public Animator animator;
    public int nextLevel;
    
    private bool isCarScene;
    private float iniScale, timerToChange;
    private bool hasChanged;
    private int levelToLoad, currentLevel;

    public static SceneController instance;

    private void Awake()
    {
        
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        iniScale = player.transform.localScale.x;
        isCarScene = hasChanged = false;
        if (SceneManager.GetActiveScene().buildIndex == 3) isCarScene = true;
        else
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }
    public void SetPlayerInstance(GameObject obj)
    {
        player = obj;
        loadedScene();
    }

    private void loadedScene()
    {
        iniScale = player.transform.localScale.x;
        isCarScene = hasChanged = false;
        if (SceneManager.GetActiveScene().buildIndex == 3) isCarScene = true;
        else
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (isCarScene)
        {
            if (player.transform.position.z >= 1030)
            {
                Fade();
            }
        }
        else
        {
            if (!hasChanged)
            {
                if (iniScale < player.transform.localScale.x)
                {
                    hasChanged = true;
                    timerToChange = 0.0f;
                }
            }
            else
            {
                timerToChange += Time.deltaTime;
                if (timerToChange >= 0.5f)
                {
                    hasChanged = false;
                    timerToChange = 0.0f;
                    Fade(3);
                }
            }
        }
        if (player.transform.childCount <= 0) //lose condition
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            loadedScene();
        }

    }

    void Fade(params int[] lvl)
    {
        if (lvl.Length == 0)
        {
            //will work with complete scenes
            //if (currentLevel < 1) levelToLoad = currentLevel + 1;
            //else levelToLoad = 1;

            levelToLoad = 1;

        }
        else
        {
            levelToLoad = lvl[0];
        }


        animator.SetTrigger("fadeout");
    }

    void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        loadedScene();
        animator.SetTrigger("fadein");
    }
}
