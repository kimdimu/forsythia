using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayer : MonoBehaviour
{
    public bool IsStrong = false;
    public bool IsWeak = false;

    int JumpCount = 0;

    Vector3 offset;

    void Start()
    {
        IsStrong = false;
        IsWeak = false;

        offset = transform.position; //현재(처음)위치 저장
    }

    void Update()
    {
        //강하게 눌렀을 때 + 약하게 안 눌렀을 때 (중복 선택 방지)
        if(IsStrong && !IsWeak)
        {
            for(int i = 0; i < 2; i++)
            {
                JumpCount++;
                //transform.Translate(new Vector3(transform.position, transform.position, transform.position));
                Debug.Log("강하게" + i);
                if (JumpCount < 2)
                {
                    JumpCount = 0;
                    IsStrong = false;
                }
            }
        }

        //약하게 눌렀을 때 + 강하게 안 눌렀을 때 (중복 선택 방지)
        if (IsWeak && !IsStrong)
        {
            JumpCount++;
            transform.Translate(new Vector3(0, 0, 0));
            if (JumpCount == 1)
            {
                JumpCount = 0;
                IsStrong = false;
                Debug.Log("약하게");
            }
        }
    }
}
