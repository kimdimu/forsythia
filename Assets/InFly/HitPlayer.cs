﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    int SunScore = 50;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //클론이 Player 태그와 충돌하면
        {
            if(InGamePlayer.BigSuccess)
            {
                //score = score + (SunScore * 1.5f) 
            }
            if (InGamePlayer.Success)
            {
                //score = score + SunScore;
            }
        }
    }
}
