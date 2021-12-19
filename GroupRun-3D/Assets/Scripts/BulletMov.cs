using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    private float aliveTime, lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lifeTime = 10f;
        aliveTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        aliveTime += Time.deltaTime;
        if (aliveTime>=lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
