using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMov : MonoBehaviour
{
    public GameObject player;
    public float offsetChangeY = 90, offsetChangeZ = 80;

    private float offset, timerAfterPhaseChange;
    private bool changedPhase;
    float yVelocity = 0.0f;

    private Vector3 iniplayerScale, targetPos;

    // Use this for initialization
    void Start()
    {
        changedPhase = false;
        iniplayerScale = player.transform.localScale;
        offset = transform.position.z - player.transform.position.z;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, offset + player.transform.position.z);
        if (player.transform.localScale.x > iniplayerScale.x && !changedPhase)
        {

            changedPhase = true;
            timerAfterPhaseChange = 0.0f;
            targetPos.y = offsetChangeY + player.transform.position.y;
            targetPos.z = player.transform.position.z;
        }

        if (changedPhase)
        {
            timerAfterPhaseChange += Time.deltaTime;
            if (transform.position.y < targetPos.y)
            {
                float newPositionY = Mathf.SmoothDamp(transform.position.y, targetPos.y, ref yVelocity, 0.3f);
                float newPositionZ = Mathf.SmoothDamp(transform.position.z, targetPos.z, ref yVelocity, 0.3f);
                transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
            }

        }
    
    }



}
