using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawnerScript : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    public GameObject playergroup;
    public float SpeedZcar;
    
    private float timeToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn += Time.deltaTime;
        if (timeToSpawn > 2.0f && (playergroup.transform.position.z < 1000.0f))
        {
            int index = Random.Range(0, cars.Count);
            Vector3 spawnCoord = new Vector3(Random.Range(-35, 35), 0.0f, transform.position.z);
            var newCar = GameObject.Instantiate(cars[index], spawnCoord, transform.rotation);
            newCar.transform.position = new Vector3 (newCar.transform.position.x, getYPositionCar(index), transform.position.z);
            newCar.transform.parent = gameObject.transform;
            newCar.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, SpeedZcar);
            timeToSpawn = 0.0f;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.position.z <= -40) Destroy(transform.GetChild(i).gameObject);
        }

    }

    private float getYPositionCar (int index)
    {
        switch(index)
        {
            case 0:
                return 10f;

            case 1:
                return 7f;

            case 2:
                return 6f;

            case 3:
                return 13f;

            case 4:
                return 6f;

            default:
                return 0;

        }
    }
}
