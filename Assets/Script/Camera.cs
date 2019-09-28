using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
<<<<<<< HEAD
    public Transform target;    //추적할 타겟
    public float dist = 90f;    //카메라와의 거리
    public float height = 70f;   //카메라의 높이
    public float dampRotate = 5f;   //회전

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

=======
    public float MoveSpeed;     // 플레이어를 따라오는 카메라 맨의 스피드.

    // 비공개
    private Transform Target;   // 플레이어의 트랜스 폼.
    private Vector3 Pos;        // 자신의 위치.

    void Start()
    {
        // Player라는 태그를 가진 오브젝트의 transform을 가져온다.
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // 플레이어를 따라다님.
>>>>>>> parent of 702ab88... Camera2
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
