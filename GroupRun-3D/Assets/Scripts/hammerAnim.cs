using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerAnim : MonoBehaviour
{
    private Animator anim;
    public bool isLeft;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isLeft", isLeft);
    }

    public void HammerHit()
    {
        ps.Play();
        FindObjectOfType<AudioManager>().Play("hammerHit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
