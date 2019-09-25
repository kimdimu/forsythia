using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeafPutScript : MonoBehaviour
{
    public GameObject Leaf;
    private int iCount;
    private float CurClock;
    // Start is called before the first frame update
    void Start()
    {
        iCount = 0;
        CurClock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurClock += Time.deltaTime;


        if (CurClock > 0.7f)
        {
            float RandomXPos = Random.Range(580, 650);
            float RandomZPos = Random.Range(0, 70);
            float RandomQuat = Random.Range(0, 180);
            float RandomQuat2 = Random.Range(0, 180);
            float RandomQuat3 = Random.Range(0, 180);

            if (iCount <= 50)
            {
                Instantiate(Leaf, new Vector3(RandomXPos, 1150, RandomZPos), Quaternion.Euler(RandomQuat3, RandomQuat, RandomQuat2));
                iCount++;
                if (iCount <= 30) // 무한생성
                    iCount = 0;
            }
            CurClock = 0.0f;
        }
    }
}


//일정시간 지나면 삭제 
//회전 Quaternion을 바꿔줘야함
// 흩날리도록