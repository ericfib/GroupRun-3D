using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speedX = 5.0f;
    public float speedZ = 10.0f;
    private float? lastMousePoint = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePoint = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastMousePoint = null;
        }
        if (lastMousePoint != null)
        {
            float difference = Input.mousePosition.x - lastMousePoint.Value;
            transform.position = new Vector3(transform.position.x + (difference / 188) * Time.deltaTime, transform.position.y, transform.position.z);
            lastMousePoint = Input.mousePosition.x;
        }

        gameObject.transform.Translate(0.0f, 0.0f, speedZ * Time.deltaTime);

    }
}
