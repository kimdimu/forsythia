using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Quaternion targetRote; 
    public float fSpeed = 2.0f;

    private float fHeight = 0.0f;

    private Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(270 ,45,-270); //이새끼 왜 로테이션이 쳐안먹히는거야

        fHeight = Random.Range(19.0f, 25.0f); //펄럭펄럭 

        Vector3 Pos = target.position + new Vector3(0.0f, fHeight, 0.0f); //거리

        transform.position = Vector3.Lerp(transform.position, Pos, Time.deltaTime * fSpeed);//거리가 생기면 따라오도록
        //transform.position += (target.position - Pos) * fSpeed;
        //transform.position -= new Vector3(3.0f, 0, 3.0f);
        transform.LookAt(target);
    }
}
