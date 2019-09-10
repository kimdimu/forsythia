using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravityBody : MonoBehaviour
{
    // Start is called before the first frame update

    public PlanetGravityAttractor attractor;
    private Transform myTransform;

    void Start()
    {
        //GetComponent<Rigidbody>();
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        //rigidbody.useGravity = false;

        //myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //attractor.Attract(myTransform);
    }
}
