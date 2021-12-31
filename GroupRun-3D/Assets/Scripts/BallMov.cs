using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMov : MonoBehaviour
{
    private float rotationSpeed;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = moveSpeed * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosz = transform.position.z - (moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newPosz);
        transform.Rotate(-rotationSpeed * Time.deltaTime, 0.0f, 0.0f);


        if (transform.position.z <= -500f) Destroy(transform.gameObject);

    }
}
