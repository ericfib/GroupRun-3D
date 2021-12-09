using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject player, finishObject;
    public Animator animator;
    public int nextLevel;
    public bool isCarScene;
    
    private float iniScale, timerToChange;
    private bool hasChanged;
    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        iniScale = player.transform.localScale.x;
        hasChanged = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCarScene)
        {
            if ((finishObject.transform.position.z - player.transform.position.z) < 1.0f)
            {
                Fade(nextLevel);
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
                if (timerToChange >= 0.5f) Fade(3);
            }
        }
       
            
    }

    void Fade(int lvltoload)
    {
        levelToLoad = lvltoload;
        animator.SetTrigger("fadeout");
    }

    void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
