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
        if (CurClock > 1.5f)
        {
            CreateLeaf();
            CreateLeafSecond();
            CreateLeafThird();
            CurClock = 0.0f;
        }
    }

    void CreateLeaf()
    {

        float RandomXPos = Random.Range(400, 700);
        float RandomZPos = Random.Range(-150, 150);
        float RandomQuat = Random.Range(0, 180);
        float RandomQuat2 = Random.Range(0, 180);
        float RandomQuat3 = Random.Range(0, 180);

        if (iCount <= 150)
        {
            var o = Instantiate(Leaf, new Vector3(RandomXPos, 1150, RandomZPos), Quaternion.Euler(RandomQuat3, RandomQuat, RandomQuat2));
            iCount++;
            Destroy(o, 10.0f);
            if (iCount >= 100) // 100개가 넘으면 삭제 속도 빠르게 ㄱㄱ 추가하자 
                iCount = 0;
        }
    }

    void CreateLeafSecond()
    {
        float RandomXPos = Random.Range(600, 900);
        float RandomZPos = Random.Range(-250, 50);
        float RandomQuat = Random.Range(0, 90);
        float RandomQuat2 = Random.Range(0, 90);
        float RandomQuat3 = Random.Range(0, 90);

        if (iCount <= 150)
        {
            iCount++;
            var p = Instantiate(Leaf, new Vector3(RandomXPos, 1150, RandomZPos), Quaternion.Euler(RandomQuat2, RandomQuat, RandomQuat3));
            Destroy(p, 10.0f);

        }
    }

    void CreateLeafThird()
    {
        float RandomXPos = Random.Range(500, 800);
        float RandomZPos = Random.Range(-100, 200);
        float RandomQuat = Random.Range(0, 90);
        float RandomQuat2 = Random.Range(0, 90);
        float RandomQuat3 = Random.Range(0, 90);

        if (iCount <= 150)
        {
            iCount++;
            var q = Instantiate(Leaf, new Vector3(RandomXPos, 1150, RandomZPos), Quaternion.Euler(RandomQuat2, RandomQuat, RandomQuat3));
            Destroy(q, 10.0f);

        }
    }
}


//일정시간 지나면 삭제 
//회전 Quaternion을 바꿔줘야함
// 흩날리도록