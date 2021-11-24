using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speedX = 5.0f;
    public float speedZ = 10.0f;
    private float? lastMousePoint;
    private float startX, floorWidth;
    public GameObject floor;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        lastMousePoint = null;
        startX = transform.position.x;
        floorWidth = floor.GetComponent<Renderer>().bounds.size.x - 8f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, speedZ);
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
            float newPosx = transform.position.x + (difference * speedX) * Time.deltaTime;
            if (newPosx < (startX + floorWidth/2) && newPosx > (startX - floorWidth/2))
            {
                rb.MovePosition(new Vector3(newPosx, transform.position.y, transform.position.z));
            }
            lastMousePoint = Input.mousePosition.x;
        }

    }
}
