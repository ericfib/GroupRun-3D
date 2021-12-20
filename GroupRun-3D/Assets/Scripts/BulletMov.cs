using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= 2f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
