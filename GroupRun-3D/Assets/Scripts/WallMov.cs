using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMov : MonoBehaviour
{
    public enum MoveMode
    {
        left,
        right
    };

    public float moveArea = 5f;
    public float moveSpeed = 5f;
    public MoveMode mode = MoveMode.left;

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
        //side movement control
        switch (currentMode)
        {
            case MoveMode.left:
                float newPosx = transform.position.x - (moveSpeed * Time.deltaTime);
                if (newPosx < limL) currentMode = MoveMode.right;
                else transform.position = new Vector3(newPosx, transform.position.y, transform.position.z);
                break;

            case MoveMode.right:
                float newPos = transform.position.x + (moveSpeed * Time.deltaTime);
                if (newPos > limR) currentMode = MoveMode.left;
                else transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
                break;


        }
    }
}
