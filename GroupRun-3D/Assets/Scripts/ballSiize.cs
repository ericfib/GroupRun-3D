using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSiize : MonoBehaviour
{
    float smoothTime = 3.0f;
    float yVelocity = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 10)
        {
        float newPosition = Mathf.SmoothDamp(transform.localScale.x, 10.0f * transform.localScale.x, ref yVelocity, smoothTime);
        transform.localScale = new Vector3(newPosition, newPosition, newPosition);
        }
    }
}
