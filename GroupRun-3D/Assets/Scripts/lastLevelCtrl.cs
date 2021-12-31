using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastLevelCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int lvl = FindObjectOfType<SceneController>().getCurrentLevel();
        if (lvl >= 5)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
