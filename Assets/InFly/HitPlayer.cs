using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //클론이 Player 태그와 충돌하면
        {
            Debug.Log("닿임");
        }
    }
}
