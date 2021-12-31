using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speedX;
    public float speedZ;
    public GameObject floor;
    public int maxChildren = 15;

    private Rigidbody rb;
    private float startScale;
    private bool hasEvolved;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, speedZ);
        hasEvolved = false;
        startScale = transform.localScale.x;

        FindObjectOfType<SceneController>().SetPlayerInstance(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > startScale && !hasEvolved) hasEvolved = true;

        else rb.velocity = new Vector3(rb.velocity.x, 0.0f, speedZ);


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            bool filltocaBorde = watchChildrenBorders(true);
            float newPosx = transform.position.x - (speedX * Time.deltaTime);

            if (filltocaBorde == false)
            {
                rb.MovePosition(new Vector3(newPosx, transform.position.y, transform.position.z));
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            bool filltocaBorde = watchChildrenBorders(false);
            float newPosx = transform.position.x + (speedX * Time.deltaTime);

            if (filltocaBorde == false)
            {
                rb.MovePosition(new Vector3(newPosx, transform.position.y, transform.position.z));
            }

        }

     }

    private bool watchChildrenBorders(bool left)
    {

        int n_children = transform.childCount;
        for (int i = 0; i < n_children; i++)
        {

            Vector3 child_pos = transform.GetChild(i).transform.position;
            float newPosx;
            if (left) newPosx = child_pos.x - (speedX * Time.deltaTime);
            else newPosx = child_pos.x + (speedX * Time.deltaTime);
            if (newPosx < -40 || newPosx > 40) return true;
        }

        return false; 
    }

}

