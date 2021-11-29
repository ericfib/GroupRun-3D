using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesMovement : MonoBehaviour
{
    public enum MoveMode
    {
        left,
        right
    };

    public enum SpikeState
    {
        on,
        off
    };

    public bool moving;
    public float moveArea = 5f;
    public float moveSpeed = 5f;
    public MoveMode mode = MoveMode.left;

    public bool spikesSwitch;
    public float onTime;
    public float offTime;

    private float limL, limR;
    private MoveMode currentMode;
    private SpikeState currentState;
    private float timeElapsed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //inicializamos las spikes activadas (para el Animator)
        anim = GetComponent<Animator>();
        anim.SetBool("activated", true);

        if (moving) //init movimiento lateral de los pinchos
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

        if (spikesSwitch) //init del control on/off de los pinchos
        {
            currentState = SpikeState.on;
            timeElapsed = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
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

        if (spikesSwitch)
        {
            timeElapsed += Time.deltaTime;

            switch (currentState)
            {
                case SpikeState.on:
                    if (timeElapsed >= onTime)
                    {
                        anim.SetBool("activated", false);
                        currentState = SpikeState.off;

                        timeElapsed = 0;
                    }
                    break;

                case SpikeState.off:
                    if (timeElapsed >= offTime)
                    {
                        anim.SetBool("activated", true);
                        currentState = SpikeState.on;

                        timeElapsed = 0;
                    }
                    break;
            }
        }
    }
}
