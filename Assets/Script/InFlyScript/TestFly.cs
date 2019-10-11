using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestFly : MonoBehaviour
{
    public GameObject LeftBotton;
    public GameObject RightBotton;

    public static float MoveSpeed = 50; //좌우로 움직일 스피드
    public static float BirdSpeed = 200; //직진으로 움직일 스피드

    public static float FlyTime = 15; //비행 게이지 끝나는 시간
    public static bool IsFlyEnd; //비행이 끝났으면

    void Start()
    {
        IsFlyEnd = false;
    }

    void Update()
    {
        FlyTime -= Time.deltaTime; //일정한 시간에 따라 감소됨
        transform.position += Vector3.forward * BirdSpeed * Time.deltaTime;  //새는 자동으로 계속 앞으로 간다
        //비행 게이지가 모두 떨어지면
        if (FlyTime <= 0)
        {
            IsFlyEnd = true;
            SceneManager.LoadScene("TestInGame");
        }
    }
}
