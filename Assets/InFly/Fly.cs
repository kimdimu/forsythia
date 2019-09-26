﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fly : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject plyer; //움직일 오브젝트

    public float speed; //좌우로 움직일 스피드
    public float BirdSpeed; //직진으로 움직일 스피드

    bool right, left, IsRight, IsLeft;

    void Start()
    {
        right = false;
        left = false;
        IsRight = false;
        IsLeft = false;
    }
    void Update()
    {
        //새는 자동으로 계속 앞으로 간다
        plyer.transform.position += Vector3.forward * BirdSpeed * Time.deltaTime;

        if (left)
        {
            plyer.transform.position += Vector3.left * speed * Time.deltaTime;
            //왼쪽 화면으로 나가려고 할 경우
            if (plyer.transform.position.x <= 460)
            {
                plyer.transform.position = new Vector3(460, plyer.transform.position.y,
                     plyer.transform.position.z);
            }
        }
        if(right)
        {
            plyer.transform.position += Vector3.right * speed * Time.deltaTime;
            //오른쪽 화면으로 나가려고 할 경우
            if (plyer.transform.position.x >= 600)
            {
                plyer.transform.position = new Vector3(600, plyer.transform.position.y,
                     plyer.transform.position.z);
            }
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
