using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject finishObject;
    private GameObject player;
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

        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 6)
        {

            iniScale = player.transform.localScale.x;
            isCarScene = hasChanged = false;
            int buildindex = SceneManager.GetActiveScene().buildIndex;

            if (buildindex == 3) isCarScene = true;
            else if (buildindex > 0 && buildindex < 6)
            {
                currentLevel = SceneManager.GetActiveScene().buildIndex;
            }
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
        if (SceneManager.GetActiveScene().buildIndex == 6) isCarScene = true;
        else
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex <= 6)
        {

            if (isCarScene)
            {
                if (player.transform.position.z >= 1000) //go next level
                {
                    SceneManager.LoadScene(8);
                    if (currentLevel == 5)
                    {
                        GameObject.Find("/Canvas/Menu/NextLevel").SetActive(false);
                    }
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
                    if (timerToChange >= 0.5f) //start fase 2 (cars)
                    {
                        hasChanged = false;
                        timerToChange = 0.0f;
                        Fade(6);
                    }
                }
            }
            if (player.transform.childCount <= 0) //lose condition
            {

                SceneManager.LoadScene(7);

            }
        }

    }

    public void Fade(params int[] lvl)
    {
        if (lvl.Length == 0)
        {
            //will work with complete scenes
            if (currentLevel < 5) levelToLoad = currentLevel + 1;
            else
            {
                if (isCarScene)
                {
                    levelToLoad = 0;
                }
            }
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
        if (levelToLoad > 0 && levelToLoad <= 6) loadedScene();
        animator.SetTrigger("fadein");
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }
}
