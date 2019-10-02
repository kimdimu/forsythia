using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHitPlayer : MonoBehaviour
{
    float MoreSpeedTime;
    bool IsHit;

    void Update()
    {
        if(IsHit == true)
        {
            MoreSpeedTime += Time.deltaTime; //일정한 시간에 따라 증가함
        }
        //구름링을 통과한 뒤 1.5초가 지나면
        if (MoreSpeedTime >= 1.5f)
        {
            TestFly.BirdSpeed = 200; //속도 낮추기
            InFlyCamera.speed = 200;
            MoreSpeedTime = 0f; //시간 초기화
            IsHit = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") //구름링이 Player 태그와 충돌하면
        {
            TestFly.BirdSpeed = 250; //속도 증가
            InFlyCamera.speed = 300;
            IsHit = true;
        }
    }
}
