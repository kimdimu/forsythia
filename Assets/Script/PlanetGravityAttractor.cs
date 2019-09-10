﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravityAttractor : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravity = -10;

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        //body.rigidbody.AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
