using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestFly : MonoBehaviour
{
    public static float MoveSpeed = 100; //좌우로 움직일 스피드
    public static float BirdSpeed = 400; //직진으로 움직일 스피드

    public static float FlyTime = 15; //비행 게이지 끝나는 시간
    public static bool IsFlyEnd; //비행이 끝났으면

    public GameObject particle;

    void Start()
    {
        IsFlyEnd = false;
        particle.SetActive(false); //파티클 안보이게 함
    }

    void Update()
    {         
        particle.transform.position = transform.position + new Vector3(0,0,30);

        if(CloudHitPlayer.Onparicle) //구름링이 플레이어에 닿았으면
            particle.SetActive(true);
        else
            particle.SetActive(false);


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
