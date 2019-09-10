using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody>();
        
       // rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        //rigidbody.useGravity = false;
        myTransform = transform;
    }

    void Update()
    {
        attractor.Attract(myTransform);    
    }
}
