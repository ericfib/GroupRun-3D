using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject splash;
    public Animator anim;
    public GameObject splash_ps;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        string material = gameObject.GetComponent<Renderer>().material.name;
        if (other.gameObject.tag == "dieObstacle" && material.Substring(0, 7) == "PJ_Good")
        {
            Vector3 deathPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Destroy(transform.parent.gameObject);

            Instantiate(splash, deathPos, transform.rotation);
            Instantiate(splash_ps, new Vector3(deathPos.x, transform.position.y + 5f, deathPos.z), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("playerDeath");
        }

    }
}
