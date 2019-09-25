﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public GameObject target;
    InGamePlayer playerScript;

    void Start()
    {
        playerScript = target.GetComponent<InGamePlayer>();
    }
    
    public void Strong()
    {
        playerScript.IsStrong = true;
    }

    public void Weak()
    {
        playerScript.IsWeak = true;
    }

    public void LeftJump()
    {
        playerScript.IsLeftJump = true;
    }

    public void RightJump()
    {
        playerScript.IsRightJump = true;
    }
    //일시정지
    public void ActivePauseBt()
    {
        Time.timeScale = 0; //시간 흐름을 0으로 만듦
    }
}
