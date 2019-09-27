using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject[] Sphere; //복제 될 햇살 [종류]
    GameObject firstground; //처음 햇살 생성 위치
    //GameObject LeftWall; //처음 햇살 생성 위치
    //GameObject RightWall; //처음 햇살 생성 위치

    GameObject obj; //클론 받아오는 오브젝트
    List<GameObject> SunList = new List<GameObject>(); //오브젝트 리스트 생성

    int ranSphere; //랜덤 [종류] 받아오기 위한 변수
    int ranX; //z좌표 랜덤으로 받기 위한 변수
    //int ranZ; //z좌표 랜덤으로 받기 위한 변수

    void Start()
    {
        firstground = GameObject.FindGameObjectWithTag("Sun"); //처음 발판의 위치 받아오기 위해 사용
       // LeftWall = GameObject.FindGameObjectWithTag("LeftWall"); //왼쪽 벽 위치 받아오기 위해 사용
       // RightWall = GameObject.FindGameObjectWithTag("RightWall"); //오른쪽 벽의 위치 받아오기 위해 사용
        SunInIt(); //햇살 생성 시작
    }

    void Update()
    {
        /*햇살 [종류]
         [0] = 직선 / [1] = 뒤 왼쪽 세개, 앞 오른쪽 세개 / [2] = 앞 왼쪽 세개, 뒤 오른쪽 세개 /
         [3] = 왼쪽에서 오른쪽으로 대각선 / [4] = 오른쪽에서 왼쪽으로 대각선
         */

        //만약 비행 게이지가 0이 되어 비행이 끝나면
        if(Fly.IsFlyEnd == true)
        {
            Destroy(obj.gameObject); //클론을 지운다
        }
    }

    //햇살 생성 시키는 함수
    void SunInIt()
    {
        //비행 게이지가 끝날 때까지 생성
        for (int i = 0; i < Fly.FlyTime; i++)
        {
            ranSphere = Random.Range(0, 5); //0~4까지 랜덤 생성
            ranX = Random.Range(460, 600);
            //ranZ = Random.Range(200, 400);

            obj = (GameObject)Instantiate(Sphere[ranSphere], firstground.transform.position, firstground.transform.rotation);
            obj.transform.localScale = new Vector3(4f, 4f, 4f); //콜론 크기 변경

            SunList.Add(obj);

            ////왼쪽 벽을 넘어갔거나 오른쪽 벽을 넘어갔으면 그 벽의 위치로 x좌표 지정
            //if (SunList[i].transform.position.x <= LeftWall.transform.position.x)                
            //{
            //    SunList[i].transform.position = new Vector3(LeftWall.transform.position.x,
            //        firstground.transform.position.y, transform.position.z + 200 * i);
            //}
            //if(SunList[i].transform.position.x >= RightWall.transform.position.x)
            //{
            //    SunList[i].transform.position = new Vector3(RightWall.transform.position.x,
            //       firstground.transform.position.y, transform.position.z + 200 * i);
            //}
            //else
            //{
                //x좌표는 랜덤, 생성 위치의 y좌표, z좌표는 랜덤 (앞 햇살과 랜덤으로 거리 조정하여 생성)
                SunList[i].transform.position = new Vector3(ranX,
                   firstground.transform.position.y, transform.position.z + 200 * i);
            //}
        }
    }
}
