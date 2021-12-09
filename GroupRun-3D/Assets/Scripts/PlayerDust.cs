using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDust : MonoBehaviour
{
    public ParticleSystem rightDust, leftDust;
    public void rightStep()
    {
        rightDust.Play();
    }

    public void leftStep()
    {
        leftDust.Play();
    }
}
