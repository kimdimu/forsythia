using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void onTriggerEnter(Collider col) // 박스 영역에 들어오면 호출
    {
        if (col.gameObject.tag == "fly")
        {
            Debug.Log("chechekhckhekhckehkche!");
            InGamePlayer.flyCheck = true;
        }
    }

}
