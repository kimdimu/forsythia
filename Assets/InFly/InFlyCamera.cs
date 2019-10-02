using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFlyCamera : MonoBehaviour
{
    public float speed; //카메라 스피드

    void Start()
    {
        
    }
    
    void Update()
    {
        Fly.GetSpeedTime += Time.deltaTime; //일정한 시간에 따라 증가함

        //새와 함께 움직여야 함으로 새가 앞으로 나아가는 스피드와 같아야 한다. Fly.BirdSpeed
        transform.position += Vector3.forward * speed * Time.deltaTime;

        //시작하고 3초동안은 빠르게 나아간다
        if (Fly.GetSpeedTime >= 0 && Fly.GetSpeedTime <= 3.0f)
        {
            transform.position += Vector3.forward * 282 * Time.deltaTime;
        }
    }
}
