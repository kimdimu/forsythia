using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPutScript2 : MonoBehaviour
{
    public GameObject Leaf;
    private int iCount;
    private float CurClock;
    private float DesClock;
    private int LeafCount;
    // Start is called before the first frame update
    void Start()
    {
        LeafCount = 0;
        iCount = 0;
        CurClock = 0;
        DesClock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurClock += Time.deltaTime;
        DesClock += Time.deltaTime;

        if (CurClock > 1.2)
        {
            float RandomXPos = Random.Range(500, 800);
            float RandomZPos = Random.Range(-100, 200);
            float RandomQuat = Random.Range(0, 90);
            float RandomQuat2 = Random.Range(0, 90);
            float RandomQuat3 = Random.Range(0, 90);

            if (iCount <= 50)
            {
                iCount++;
                Instantiate(Leaf, new Vector3(RandomXPos, 1150, RandomZPos), Quaternion.Euler(RandomQuat2, RandomQuat, RandomQuat3));
                //Destroy(gameObject, 10.0f);
                if (iCount <= 30)
                    iCount = 0;
            }
            CurClock = 0.0f;
            //LeafCount = Leaf.transform.childCount;
        }


    }
}
