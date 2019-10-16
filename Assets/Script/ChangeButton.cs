using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    public GameObject St;
    public GameObject We;

    Vector3 StVector; //st위치
    Vector3 WeVector; //we위치
    Vector3 TempVector; //위치 저장할 변수

    public static bool IsChange; //바뀌었는지 안 바뀌었는지

    void Start()
    {
       // IsChange = false; //안 바뀐 상태로 시작 (강 / 약)
        StVector = St.transform.position; //st의 처음위치 저장
        WeVector = We.transform.position; //we의 처음위치 저장
    }

    void Update()
    {
        St.transform.position = StVector;
        We.transform.position = WeVector;
    }

    public void ChangeBtton()
    {
        if (IsChange) //바뀌었으면
        {
            TempVector = StVector; //st위치를 temp에 저장
            StVector = WeVector; //we위치를 st에 넣음 
            WeVector = TempVector; //temp위치를 we에 저장
            IsChange = false;
        }
        else if (!IsChange) //안 바뀌었으면
        {
            TempVector = StVector;
            StVector = WeVector;
            WeVector = TempVector;
            IsChange = true;
        }
    }
}
