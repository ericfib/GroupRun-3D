using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class multiply_player : MonoBehaviour
{

    public GameObject cloneObject;
    public Vector2 regionSize = Vector2.one;
    public int maxChildren = 15;
    public ParticleSystem grow_ps;
    float yVelocity = 0.0f;

    private bool needsToEvolve;
    private float startScale;
    private Vector3 offset;
    private float cellSize, radius, timerToTransform;
    private bool psInstantiated;
    private GameObject ps;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.GetComponentInChildren<Collider>().bounds.size;

        radius = Mathf.Sqrt((offset.x * offset.x) + (offset.z * offset.z));
        cellSize = radius  / Mathf.Sqrt(2);
        timerToTransform = 0.0f;
        startScale = transform.localScale.x;
        psInstantiated = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (needsToEvolve) timerToTransform += Time.deltaTime;
        if (timerToTransform >= 0.4) destroyChildren();
        
        if(gameObject.transform.childCount == 1 && needsToEvolve)
        {
            //TRANSFORMATION
            if (transform.localScale.y <= 10.0f)
            {
                float newScale = Mathf.SmoothDamp(transform.localScale.x, 10.0f * transform.localScale.x, ref yVelocity, 4.0f);
                transform.localScale = new Vector3(newScale, newScale, newScale);
            }

            if (transform.position.y <= 52.1)
            {
                float newPosition = Mathf.SmoothDamp(transform.position.y, 42.1f + transform.position.y, ref yVelocity, 0.3f);
                transform.position = new Vector3 (transform.position.x, newPosition, transform.position.z);
            }
        }

        if (psInstantiated)
        {
            ps.transform.position = transform.position;
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("multiplier_barr"))
        {
            string aux = other.gameObject.GetComponent<TMP_Text>().text;
            int nclones = System.Convert.ToInt32(aux);
            int nchildren = gameObject.transform.childCount;
            for (int i = 0; i < nclones; i++)
            {
                Debug.Log("VOY A SPAWNEAR COSAS");
                SpawnItem();
            }
            FindObjectOfType<AudioManager>().Play("playerMultiply");
        }

        if (transform.childCount >= maxChildren)
        {
            needsToEvolve = true;
            if (!psInstantiated)
            {
                ps = Instantiate(grow_ps, transform.position, Quaternion.identity).gameObject;
                psInstantiated = true;
                FindObjectOfType<AudioManager>().Play("playerGrow");
            }
        }

        }
    
    public void SpawnItem (params int[] nChildToSpawn)
    {
        bool tooClose, found;
        tooClose = found = false;
        int n_children;
        Material originalMaterial = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Renderer>().material;

        if (nChildToSpawn.Length > 0) n_children = nChildToSpawn[0];
        else n_children = transform.childCount;

        while (found == false)
        {
            var spawnPoint = new Vector2(Random.Range(-regionSize.x, regionSize.x), Random.Range(-regionSize.y, regionSize.y));
            Vector2 aux = new Vector2(spawnPoint.x + transform.position.x, spawnPoint.y + transform.position.z);
           
            for (int i = 0; i < n_children; i++)
            {
                Vector3 child_pos = transform.GetChild(i).transform.position;
                Vector2 child_pos_xz = new Vector2(child_pos.x, child_pos.z);
                float distance = Vector2.Distance(child_pos_xz, aux);
                if (distance <= radius+0.5) tooClose = true;
            }

            if (!tooClose)
            {
                var newObj = GameObject.Instantiate(cloneObject, new Vector3(aux.x, 0.5f, aux.y), gameObject.transform.rotation);
                newObj.transform.parent = gameObject.transform;
                newObj.transform.GetChild(0).GetComponent<Renderer>().material = originalMaterial;
                found = true;

            } else
            {
                return;
            }
        }
    }

    private void destroyChildren()
    {
        int nchildren = transform.childCount;
        for (int i = 1; i < nchildren; i++)
        {
            Transform childTF = transform.GetChild(i).transform;
            Vector3 targetPostition = new Vector3(transform.position.x,
                                       childTF.position.y,
                                       transform.position.z);
            childTF.LookAt(targetPostition);
            childTF.position = Vector3.MoveTowards(childTF.position, targetPostition, 20 * Time.deltaTime);

            if (childTF.position == targetPostition)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        Vector3 targetPos = new Vector3(transform.position.x,
                                       transform.position.y,
                                       transform.position.z);

        ps.transform.position = Vector3.MoveTowards(ps.transform.position, targetPos, 20 * Time.deltaTime);
    }
   
}
