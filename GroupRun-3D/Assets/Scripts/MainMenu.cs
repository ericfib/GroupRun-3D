using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton(int lvl)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + lvl);
    }

    public void ControlsButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
