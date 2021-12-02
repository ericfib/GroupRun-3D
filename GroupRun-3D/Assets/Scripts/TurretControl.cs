using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    //shoot variables
    public GameObject firePoint, bullet;
    public float fireRate = 0.5f;
    private float noShootTime;
    private float levelTime;

    //move variables
    public int rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        noShootTime = 0f;
        levelTime = 0f;
        transform.rotation *= Quaternion.AngleAxis(transform.rotation.y - (rotationAngle), Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime;
        //shoot handle
        noShootTime += Time.deltaTime;
        
        if (noShootTime >= fireRate)
        {
            Shoot();
        }

        //move handle
        float angle = (Mathf.Sin(levelTime) * rotationAngle * Time.deltaTime);

        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);



    }

    //shoot function
    void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        noShootTime = 0;
    }
}
