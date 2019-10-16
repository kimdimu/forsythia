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

    public GameObject StopPanel;

    void Start()
    {
        IsFlyEnd = false;
        StopPanel.SetActive(false); //옵션 창 안 보이게 함
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
        if (ClickButton.IsStop) //옵션을 눌러 켜졌으면
        {
            Time.timeScale = 0; //시간 멈춤
            //BackSound.IsOff = false; //노래는 멈추지 않게 함
            //BackSound.IsOn = true;
            StopPanel.SetActive(true); //옵션 판넬 보이게 함
        }
        if (!ClickButton.IsStop) //옵션을 눌러 꺼졌으면
        {
            Time.timeScale = 1; //시간 움직임
            StopPanel.SetActive(false); //옵션 판넬 안보이게 함
        }
    }
}
