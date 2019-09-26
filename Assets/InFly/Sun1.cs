using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun1 : MonoBehaviour
{
    GameObject SunPosition; //처음 햇살의 위치 (햇살이 생성될 위치)

    public GameObject sun; //복제될 햇살 첫 번째

    int GetSun; //닿인 햇살의 개수

    bool IsEnd = false; //코루틴 끝내기 위한 변수
    bool TagSun = false; //햇살에 닿였으면
    bool IsClon = false; //현재 클론이 생성되어 있는지 아닌지 판단. false = 생성x, true = 생성o

    float speedRan; //햇살의 스피드 랜덤으로 바꿀 변수
    float IEnRan; //코루틴 실행 시간 랜덤으로 바꿀 변수
    int sunPran; //처음 생성될 햇살의 위치 랜덤으로 지정

    GameObject Sun_2Obj;
    GameObject Sun_3Obj;

    void Start()
    {
        Sun_2Obj = GameObject.Find("Sun_2"); //Sun_2 오브젝트를 찾는다
        Sun_3Obj = GameObject.Find("Sun_3"); //Sun_3 오브젝트를 찾는다

        IsEnd = false;
        TagSun = false;
        IsClon = false;

        SunPosition = GameObject.FindGameObjectWithTag("Sun"); //처음 클론의 위치 받아오기 위해 사용
    }
    
    void Update()
    { 
        //x좌표 랜덤으로 지정, 시작 위치 랜덤으로 지정
     //   sun.transform.position = new Vector3(Random.Range(460, 600), SunPosition.transform.position.y,
     //SunPosition.transform.position.z + 400f);

        sun.transform.position += Vector3.back * speedRan * Time.deltaTime;

        //지정 좌표까지 갔고 닿이지 않았다면
        if (sun.transform.position.z <= -100.0f && !TagSun)
        {
            //랜덤으로 지정된 처음 좌표로 옮김
            sun.transform.position = new Vector3(SunPosition.transform.position.x,
                SunPosition.transform.position.y, SunPosition.transform.position.z);
            IsClon = false; //클론 생성 안 되어있다
        }

        if (GetSun >= 2) //햇살에 두 번 닿이면
        {
            IsEnd = true; //끝낼 수 있다
        }
    }

    void MakeSun()
    {
        IEnRan = Random.Range(10, 15); //생성되는 시간 랜덤으로 지정
        speedRan = Random.Range(40.0f, 100.0f); //스피드 랜덤으로 지정
        sunPran = Random.Range(0, 4);

        //Sun_2 물체랑 나의(Sun_1) z좌표 거리가 100보다 크거나 -100보다 작고
        //Sun_3 물체랑 나의(Sun_1) z좌표 거리가 100보다 크거나 -100보다 작으면 생성한다
        if ((Sun_2Obj.transform.position.z - sun.transform.position.z > 100 ||
            Sun_2Obj.transform.position.z - sun.transform.position.z < -100) &&
            (Sun_3Obj.transform.position.z - sun.transform.position.z > 100 ||
            Sun_3Obj.transform.position.z - sun.transform.position.z < -100) &&
            IsClon == false && IsEnd == false)
        {
            //x좌표 랜덤으로 지정, 시작 위치 랜덤으로 지정
            sun.transform.position = new Vector3(Random.Range(460, 600), SunPosition.transform.position.y,
                SunPosition.transform.position.z);
            TagSun = false; //IEnRan초마다 (생성될 때마다) 닿이지 않았음으로 초기화
            IsClon = true; //클론 생성되어있음 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //햇살이 Player 태그와 충돌하면
        {
            //랜덤 지정된 처음 좌표로 옮긴다
            sun.transform.position = new Vector3(SunPosition.transform.position.x,
                SunPosition.transform.position.y, SunPosition.transform.position.z);
                
            GetSun++; //얻은 햇살 개수 증가
            TagSun = true; //햇살에 닿였다
            IsClon = false; //클론 생성 안 되어있다
        }

        if (collision.gameObject.tag == "MoveSun") //햇살이 MoveSun 태그와 충돌하면 (다른 햇살과 겹치면)
        {
            //랜덤 지정된 처음 좌표로 옮긴다
            sun.transform.position = new Vector3(SunPosition.transform.position.x,
                SunPosition.transform.position.y, SunPosition.transform.position.z);
            IsClon = false; //클론 생성 안 되어있다
        }
    }
}
