using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_Gen : MonoBehaviour
{
    public List<GameObject> flora = new List<GameObject>();
    public Vector2 regionSize;
    public int maxPoints, radius;
    private List<Vector2> points;
    public bool isright;

    
    // Start is called before the first frame update
    void Start()
    {
        regionSize = new Vector2(200, 400);
        points = PoissonDiscSampling.GeneratePoints(50, regionSize, maxPoints);

        foreach (Vector2 p in points)
        {
            int index = Random.Range(0, flora.Count);
            GameObject newObj;

            if (!isright) newObj = GameObject.Instantiate(flora[index], new Vector3(p.x + (transform.position.x), 0.0f, (p.y+transform.position.z)), gameObject.transform.rotation);
            else newObj = GameObject.Instantiate(flora[index], new Vector3(p.x + 80f, 0.0f, (p.y + transform.position.z)), gameObject.transform.rotation);
            newObj.transform.parent = gameObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
