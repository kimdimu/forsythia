using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPutScript1 : MonoBehaviour
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


        if (CurClock > 1.3f)
        {
            float RandomXPos = Random.Range(500, 575);
            float RandomZPos = Random.Range(0, 70);
            float RandomQuat = Random.Range(0, 90);
            float RandomQuat2 = Random.Range(0, 90);
            float RandomQuat3 = Random.Range(0, 90);

            if (iCount <= 50)
            {
                Instantiate(Leaf, new Vector3(RandomXPos, 1150, RandomZPos), Quaternion.Euler(RandomQuat2, RandomQuat, RandomQuat3));
                iCount++;
                if (iCount <= 30)
                    iCount = 0;
            }
            CurClock = 0.0f;
        }
    }
}
