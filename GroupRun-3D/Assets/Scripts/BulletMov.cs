using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
