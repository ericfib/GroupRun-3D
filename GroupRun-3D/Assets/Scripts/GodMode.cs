using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class GodMode : MonoBehaviour
{
    public List<Material> materials;

    private KeyCode[] levels = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5 };
    private bool isActive;
    private float timerToActivate, timerToSpawn, timerToChangeScene;
    // Start is called before the first frame update
    void Start()
    {
        //normal = new Color(0.769f, 1.000f, 1.000f, 0f);
        //godmode = new Color(1f, 0.996f, 0.768f, 1f);
        isActive = false;
        timerToSpawn = timerToActivate = timerToChangeScene = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        timerToActivate += Time.deltaTime;
        timerToSpawn += Time.deltaTime;
        timerToChangeScene += Time.deltaTime;

        if (Input.GetKey(KeyCode.G) && timerToActivate >= 1f)
        {
            timerToActivate = 0f;
            changePlayerColors();
            isActive = !isActive;
            if (isActive) FindObjectOfType<AudioManager>().Play("activeGodMode");
        }

        foreach(KeyCode kcode in levels)
        {
            if (Input.GetKey(kcode) && isActive && timerToChangeScene >= 1.5f)
            {
                timerToChangeScene = 0f;
                loadLevel(kcode);
            }
        }

        if (Input.GetKey(KeyCode.Q) && timerToSpawn >= 1f)
        {
            int sceneindex = SceneManager.GetActiveScene().buildIndex;
            if (isActive && (sceneindex >= 1 && sceneindex <= 5))
            {
                multiply_player mult_script = transform.GetComponent<multiply_player>();
                mult_script.SpawnItem(1);
                timerToSpawn = 0f;
            }
        }
    }


    private void loadLevel(KeyCode kcode)
    {
        string value = kcode.ToString();
        SceneController sc_controller = FindObjectOfType<SceneController>();
        switch (value)
        {
            case "Alpha1":
                sc_controller.Fade(1);
                break;
            case "Alpha2":
                sc_controller.Fade(2);
                break;
            case "Alpha3":
                sc_controller.Fade(3);
                break;
            case "Alpha4":
                sc_controller.Fade(4);
                break;
            case "Alpha5":
                sc_controller.Fade(5);
                break;
        }
            
    }

    private void changePlayerColors()
    {
        int nchild = transform.childCount;

        for (int i = 0; i < nchild; i++)
        {
            var childMuneco = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0);

            if (isActive) childMuneco.gameObject.GetComponent<Renderer>().material = materials[0];
            else childMuneco.gameObject.GetComponent<Renderer>().material = materials[1];
        }
    }
}
