using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMov : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float attackRange;
    private float dist;
    private Animator anim;
    private bool exploding;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        exploding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!exploding)
        {

            dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= attackRange)
            {
                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                transform.position += transform.forward * Time.deltaTime * speed;

                anim.SetBool("walk", true);
            }

            else
            {
                anim.SetBool("walk", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !exploding)
        {
            anim.SetTrigger("attack01");
            FindObjectOfType<AudioManager>().Play("bombExplosion");
            exploding = true;
        }

    }
}
