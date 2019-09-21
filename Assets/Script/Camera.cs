using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;    //추적할 타겟
    public float dist = 90f;    //카메라와의 거리
    public float height = 70f;   //카메라의 높이
    public float dampRotate = 5f;   //회전

    private Transform tr;

    int aa;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        //카메라 y 축을 타겟의 y축 회전각도로 부드럽게 회전
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,dampRotate * Time.deltaTime);
        //쿼티니언으로 변경
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

        //카메라 위치 설정후 타겟바라보게하기
        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);
    }
}
