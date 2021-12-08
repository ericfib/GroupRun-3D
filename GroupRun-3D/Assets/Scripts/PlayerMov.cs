using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speedX = 5.0f;
    private float speedZ = 50.0f;
    public GameObject floor;
    public int maxChildren = 15;

    private Rigidbody rb;
    private float? lastMousePoint;
    //private float startX, floorWidthStart, floorWidthEnd
    private float startScale;
    private bool hasEvolved;

    // Start is called before the first frame update
    void Start()
    {
        lastMousePoint = null;
        //startX = transform.position.x;
        //floorWidthStart = 80 - 8;
        //floorWidthEnd = 800 - 8;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, speedZ);
        hasEvolved = false;
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > startScale && !hasEvolved) hasEvolved = true;

        if (hasEvolved)
        {
            speedZ = 400.0f;
            rb.velocity = new Vector3(0.0f, 0.0f, speedZ);
        }
        else rb.velocity = new Vector3(0.0f, 0.0f, speedZ);

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

            bool? fillTocaBorde = null;

            fillTocaBorde = watchChildrenBorders(difference);
            float newPosx;
            if (hasEvolved) newPosx = transform.position.x + (difference * (5 * speedX)) * Time.deltaTime;
            else newPosx = transform.position.x + (difference * speedX) * Time.deltaTime;
            if (fillTocaBorde == false)
            {
                rb.MovePosition(new Vector3(newPosx, transform.position.y, transform.position.z));
            }
            lastMousePoint = Input.mousePosition.x;
        }
    }

    private bool watchChildrenBorders(float difference)
    {

        int n_children = transform.childCount;
        for (int i = 0; i < n_children; i++)
        {
            Vector3 child_pos = transform.GetChild(i).transform.position;
            float newPosx;
            if (hasEvolved)
            {
                newPosx = child_pos.x + (difference * (2 * speedX)) * Time.deltaTime;
                if (newPosx < -35 || newPosx > 700) return true;
            }
            else
            {
                newPosx = child_pos.x + (difference * speedX) * Time.deltaTime;
                if (newPosx < -40 || newPosx > 40) return true;
            }
        }

        return false; 
    }

}

