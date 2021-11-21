using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public GameObject player;

    private float offset;
    private Vector3 newPos;           
    // Use this for initialization
    void Start()
    {
       
        offset = transform.position.z - player.transform.position.z;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, offset + player.transform.position.z);
    }
}
