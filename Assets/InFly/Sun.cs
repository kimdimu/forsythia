using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject Sphere; //복제 될 햇살
    public GameObject[] firstground; //처음 햇살 생성 위치

    GameObject obj; //클론 받아오는 오브젝트
    List<GameObject> SunList = new List<GameObject>(); //오브젝트 리스트 생성

    int ranX; //z좌표 랜덤으로 받기 위한 변수
    int ranSph; //구름링 + 햇살
    int CloudSun; //구름링 + 햇살 개수 증가

    void Start()
    {
        // firstground = GameObject.FindGameObjectWithTag("Sun"); //처음 발판의 위치 받아오기 위해 사용
        SunInIt(); //햇살 생성 시작
    }

    void Update()
    {
        //만약 비행 게이지가 0이 되어 비행이 끝나면
        if(Fly.IsFlyEnd == true)
        {
            Destroy(obj.gameObject); //클론을 지운다
        }
    }

    //햇살 생성 시키는 함수
    void SunInIt()
    {
        //비행 게이지가 끝날 때까지 생성. Fly.FlyTime
        //세 개만 생성
        for (int i = 0; i < 3; i++)
        {
            //ranSph = Random.Range(0, 2);
            //ranX = Random.Range(460, 600);
            ranX = Random.Range(0, 9);

            //obj = (GameObject)Instantiate(Sphere[ranSph], firstground.transform.position, firstground.transform.rotation);
            obj = (GameObject)Instantiate(Sphere, firstground[ranX].transform.position, firstground[ranX].transform.rotation);
            obj.transform.localScale = new Vector3(35f, 35f, 5f); //구름링 클론 크기 변경

            SunList.Add(obj);

            SunList[i].transform.position = new Vector3(firstground[ranX].transform.position.x,
                firstground[ranX].transform.position.y, firstground[ranX].transform.position.z);

            //if (ranSph == 0)
            //    obj.transform.localScale = new Vector3(13f, 13f, 13f); //햇살 클론 크기 변경
            //else
            //{
            //    CloudSun++; //구름링 개수 증가
            //    obj.transform.localScale = new Vector3(35f, 35f, 5f); //구름링 클론 크기 변경
            //}
            //SunList.Add(obj);

            //if (ranSph == 1) 
            //{
            //    SunList[i].transform.position = new Vector3(ranX, firstground.transform.position.y, transform.position.z + 100 * i);
            //}
            //else
            //    SunList[i].transform.position = new Vector3(ranX, firstground.transform.position.y, transform.position.z + 200 * i);

            //if (CloudSun >= 3) //구름링 3 (또는 4개) 생성 했으면
            //    ranSph = 0; //햇살만 생성시킨다 

        }
    }
}
