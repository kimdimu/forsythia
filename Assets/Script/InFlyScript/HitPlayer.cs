using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    float SunScore = 50;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") //햇살이 Player 태그와 충돌하면
        {
         //  if (InGamePlayer.BigSuccess)
          //  {
                ScoreManager.Score += SunScore * 1.5f;
          //  }
           //else if (InGamePlayer.Success)
          //  {
                ScoreManager.Score += SunScore;
          //  }
        }
    }
}
