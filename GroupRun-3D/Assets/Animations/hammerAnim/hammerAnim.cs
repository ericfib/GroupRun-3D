using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerAnim : MonoBehaviour
{
    private Animator anim;
    public bool isLeft;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isLeft", isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
