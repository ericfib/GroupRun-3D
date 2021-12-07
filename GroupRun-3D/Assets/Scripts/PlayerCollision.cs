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
        if (other.gameObject.tag == "dieObstacle")
        {
            Vector3 deathPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Destroy(transform.parent.gameObject);

            Instantiate(splash, deathPos, transform.rotation);
            Instantiate(splash_ps, deathPos, Quaternion.identity);
        }

    }
}
