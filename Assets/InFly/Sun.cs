using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    GameObject firstSun; //처음 햇살

    public GameObject sun; //복제될 햇살 아이템
    List<GameObject> SunList = new List<GameObject>(); //오브젝트 리스트 생성

    void Start()
    {
        firstSun = GameObject.FindGameObjectWithTag("Sun"); //처음 클론의 위치 받아오기 위해 사용
        SunInit(); //햇살 클론 생성
    }
    
    void Update()
    {
        
    }

    //햇살 클론 생성시키는 함수
    void SunInit()
    {
        for (int i = 0; i < 10; i++)
        {
            //클론이 될 오브젝트, 생성 위치, 생성 회전 방향(사원수의 값), 부모의 설정
            GameObject _obj = Instantiate(sun, firstSun.transform.position, firstSun.transform.rotation) as GameObject;
            _obj.transform.localScale = new Vector3(2f, 2f, 2f); //콜론 크기 변경

            SunList.Add(_obj); //클론 i 만큼 생성 (현재 i는 총 10개, 즉 10개 클론 생성) 후 리스트에 인덱스 번호 줌

            //클론 위치 변경
            if (i % 2 == 0) //i가 짝수일 경우 왼쪽에 생성
            {
                SunList[i].transform.position = new Vector3(firstSun.transform.position.x + 15f * i,
                firstSun.transform.position.y, transform.position.z);
            }
            else //i가 홀수일 경우 오른쪽에 생성
            {
                SunList[i].transform.position = new Vector3(firstSun.transform.position.x - 15f * i,
                firstSun.transform.position.y, transform.position.z);
            }
        }
    }
}
