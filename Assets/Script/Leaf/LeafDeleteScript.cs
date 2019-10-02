using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafDeleteScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Planet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Planet")
        {
            Destroy(gameObject, 3.0f);
        }
    } 
}
