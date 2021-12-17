using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class leveldisplaytext : MonoBehaviour
{
    public TextMeshProUGUI leveldisplayer;
    
    // Start is called before the first frame update
    void Start()
    {
        int sceneindex = SceneManager.GetActiveScene().buildIndex;
        leveldisplayer.text = ("Level " + sceneindex.ToString());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
