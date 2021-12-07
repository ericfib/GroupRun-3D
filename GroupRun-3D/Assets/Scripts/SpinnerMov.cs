using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerMov : MonoBehaviour
{
    public enum MoveMode
    {
        left,
        right
    };

    public float rotationSpeed = 5f;
    public MoveMode mode = MoveMode.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == MoveMode.right)
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        else
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }

    }
}
