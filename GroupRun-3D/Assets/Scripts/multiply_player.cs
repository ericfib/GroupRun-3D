using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class multiply_player : MonoBehaviour
{

    public bool isOriginal;
    public GameObject cloneObject;
    public Vector2 regionSize = Vector2.one;

    //private int[,] grid;
    private int max = 20;
    private Vector3 offset;
    private float cellSize, radius;
    private List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector2>();
        points.Add(new Vector2(transform.position.x, transform.position.z));   
        offset = gameObject.GetComponent<Collider>().bounds.size;

        radius = Mathf.Sqrt((offset.x * offset.x) + (offset.z * offset.z));
        cellSize = radius  / Mathf.Sqrt(2);
        //grid = new int[Mathf.CeilToInt(regionSize.x / cellSize), Mathf.CeilToInt(regionSize.y / cellSize)];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("multiplier_barr") && isOriginal)
        {
            string aux = other.gameObject.GetComponent<TMP_Text>().text;
            int nclones = System.Convert.ToInt32(aux);
            int nchildren = gameObject.transform.childCount;

            if (nchildren + nclones < max)
            {
                
                    for (int i = 0; i < nclones; i++)
                    {
                        Debug.Log("VOY A SPAWNEAR COSAS");
                        SpawnItem();
                    }
            }
        }
    }

    private void SpawnItem ()
    {
        bool tooClose, found;
        tooClose = found = false;
        int cont = 0;
        while (found == false)
        {
            
            var spawnPoint = new Vector2(Random.Range(-regionSize.x, regionSize.x), Random.Range(-regionSize.y, regionSize.y));
            Vector2 aux = new Vector2(spawnPoint.x + transform.position.x, spawnPoint.y + transform.position.z);
            foreach (Vector2 point in points)
            {
                float distance = Vector2.Distance(point, aux);
                if (distance <= radius) tooClose = true;
            }

            if (!tooClose)
            {
                var newObj = GameObject.Instantiate(cloneObject, new Vector3(aux.x, transform.position.y, aux.y), gameObject.transform.rotation);
                newObj.transform.parent = gameObject.transform;
                points.Add(new Vector2(newObj.transform.position.x, newObj.transform.position.z));
                found = true;
            }
        }
    }
}
