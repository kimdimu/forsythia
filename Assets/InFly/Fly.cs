using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject plyer; //움직일 오브젝트

    public float MoveSpeed; //좌우로 움직일 스피드
    public float BirdSpeed; //직진으로 움직일 스피드

    bool right, left, IsRight, IsLeft;

    public static float FlyTime = 30; //비행 게이지 끝나는 시간

    public static bool IsFlyEnd; //비행이 끝났으면

    void Start()
    {
        right = false;
        left = false;
        IsRight = false;
        IsLeft = false;
        IsFlyEnd = false;
    }
    void Update()
    {
        FlyTime -= Time.deltaTime; //일정한 시간에 따라 감소됨. 0.1f초씩 감소함

        //새는 자동으로 계속 앞으로 간다
        plyer.transform.position += Vector3.forward * BirdSpeed * Time.deltaTime;

        if (left)
        {
            plyer.transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            //왼쪽 화면으로 나가려고 할 경우
            if (plyer.transform.position.x <= 460)
            {
                plyer.transform.position = new Vector3(460, plyer.transform.position.y,
                     plyer.transform.position.z);
            }
        }
        if (right)
        {
            plyer.transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            //오른쪽 화면으로 나가려고 할 경우
            if (plyer.transform.position.x >= 600)
            {
                plyer.transform.position = new Vector3(600, plyer.transform.position.y,
                     plyer.transform.position.z);
            }
        }
        //비행 게이지가 모두 떨어지면
        if(FlyTime <= 0)
        {
            IsFlyEnd = true;
            SceneManager.LoadScene("TestInGame");
        }
    }
    //오른쪽으로 버튼을 누르면
    public void RightFly()
    {
        IsRight = true;
    }
    //왼쪽으로 버튼을 누르면 
    public void LeftFly()
    {
        IsLeft = true;
    }
    //버튼 누르는 동안
    public void OnPointerDown(PointerEventData eventData)
    {
        if(IsRight)
        {
            right = true;
        }
        if (IsLeft)
        {
            left = true;
        }
    }
    //버튼에서 손을 떼면
    public void OnPointerUp(PointerEventData eventData)
    {
        right = false;
        left = false;
        IsRight = false;
        IsLeft = false;
    }
}
