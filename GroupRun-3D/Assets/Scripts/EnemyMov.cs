using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public GameObject player, splash, splash_ps;
    public float speed;
    public float attackRange;
    private float dist;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 deathPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(splash, deathPos, transform.rotation);
            Instantiate(splash_ps, new Vector3(deathPos.x, transform.position.y + 5f, deathPos.z), Quaternion.identity);
            Destroy(transform.gameObject);
        }

    }
}
