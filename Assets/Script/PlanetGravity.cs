using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    // Start is called before the first frame update

    public float Gravity = -50;
    
    public void Attract(Transform body)
    {
        Vector3 GravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.up;

        //body.rigidbody.AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, GravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime);
    }

 
}
