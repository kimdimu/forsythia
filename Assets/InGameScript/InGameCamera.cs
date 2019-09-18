using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCamera : MonoBehaviour
{
    public Transform target;    //추적할 타겟
    public float dist = 90f;    //카메라와의 거리
    public float height = 70f;   //카메라의 높이

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        //카메라 위치 설정후 타겟바라보게하기
        tr.position = target.position - (Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);

    }
}
