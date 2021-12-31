using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton(int lvl)
    {
        if (lvl == -1) //try again
        {
            int currentlevel = FindObjectOfType<SceneController>().getCurrentLevel();
            SceneManager.LoadScene(currentlevel);
        }
        else if (lvl == -2) //next level
        {
            int currentlevel = FindObjectOfType<SceneController>().getCurrentLevel();
            SceneManager.LoadScene(currentlevel + 1);
        }

        else
        {
            SceneManager.LoadScene(lvl);
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void clickSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void pointSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPointer");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

