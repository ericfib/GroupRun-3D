using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SawMov : MonoBehaviour
{

    public enum MoveMode
    {
        left,
        right
    };


    public float rotationSpeed = 5f;
    public float moveArea = 5f;
    public float moveSpeed = 5f;
    public MoveMode mode = MoveMode.left;
    public GameObject sparks_ps;

    private float limL, limR;
    private MoveMode currentMode;

    // Start is called before the first frame update
    void Start()
    {
        if (mode == MoveMode.right)
        {
            limR = transform.position.x + moveArea;
            limL = transform.position.x;
        }
        else
        {
            limR = transform.position.x;
            limL = transform.position.x - moveArea;

        }
        currentMode = mode;
    }

    // Update is called once per frame
    void Update()
    {
        //blade rotation
        transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime);


        //side movement control
        switch (currentMode)
        {
            case MoveMode.left:
                float newPosx = transform.position.x - (moveSpeed * Time.deltaTime);
                if (newPosx < limL) currentMode = MoveMode.right;
                else
                {
                    transform.position = new Vector3(newPosx, transform.position.y, transform.position.z);
                    sparks_ps.transform.position = new Vector3(newPosx, sparks_ps.transform.position.y, sparks_ps.transform.position.z);
                }
                break;

            case MoveMode.right:
                float newPos = transform.position.x + (moveSpeed * Time.deltaTime);
                if (newPos > limR) currentMode = MoveMode.left;
                else
                {
                    transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
                    sparks_ps.transform.position = new Vector3(newPos, sparks_ps.transform.position.y, sparks_ps.transform.position.z);
                }
                break;


        }
    }
}
