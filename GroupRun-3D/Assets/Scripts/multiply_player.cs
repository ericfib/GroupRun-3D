using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class multiply_player : MonoBehaviour
{

    public bool isOriginal;
    public GameObject cloneObject;
    public Vector2 regionSize = Vector2.one;

    private int[,] grid;
    private int max = 20;
    private Vector3 offset;
    private float cellSize, radius;
    private List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector2>();
        offset = gameObject.GetComponent<Collider>().bounds.size;

        radius = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
        cellSize = radius  / Mathf.Sqrt(2);
        grid = new int[Mathf.CeilToInt(regionSize.x / cellSize), Mathf.CeilToInt(regionSize.y / cellSize)];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("multiplier_barr") && isOriginal)
        {
            Debug.Log("colisionaaaa");
            string aux = collision.gameObject.GetComponent<TMP_Text>().text;
            int nclones = System.Convert.ToInt32(aux);
            int nchildren = gameObject.transform.childCount;
            
            if (nchildren + nclones < max)
            {
                points = PoissonDiscSampling.GeneratePoints(radius, cellSize, grid, regionSize, nclones, 30);
                Debug.Log("hay estos points: " + points.Count + ", ara imprimo jefe");
                int a = 0;
                foreach (Vector2 point in points)
                {
                    a++;
                    Debug.Log("imprimo " + cloneObject.name + "nº " + a + "en " + point.ToString());
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("multiplier_barr") && isOriginal)
        {
            Debug.Log("ME CAGO EN DIOS");
        }
    }
}
