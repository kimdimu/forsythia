using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    private float Height = 10.0f;
    private float Distance = -1.0f;
    public float fSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0);
        Vector3 Pos = target.position + new Vector3(5.0f, Height, 5.0f); //거리

        transform.position = Vector3.Lerp(transform.position, Pos, Time.deltaTime * fSpeed); //거리가 생기면 따라오도록
        //transform.position += (target.position - Pos) * fSpeed;
        transform.LookAt(target);
    }
}
