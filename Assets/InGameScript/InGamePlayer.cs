using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayer : MonoBehaviour
{
    public Rigidbody Player;

    public bool IsStrong = false; //강하게를 눌렀는지
    public bool IsWeak = false; //약하게를 눌렀는지
    bool IsPutButton = false; //버튼 누를수 있는지 없는지

    int JumpCount = 0; //점프 횟수 카운트
    int UpNum = 0; //밟은 발판 개수 카운트

    public GameObject Ground; //복제 될 물체
    List<GameObject> GroundList = new List<GameObject>(); //오브젝트 리스트 생성
    
    GameObject firstground; //처음 발판

    void Start()
    {
        IsStrong = false;
        IsWeak = false;
        IsPutButton = false;
        
        firstground = GameObject.FindGameObjectWithTag("Finish"); //처음 발판의 위치 받아오기 위해 사용
        
        GroundInit(); //발판 클론 생성
    }

    void Update()
    {
        //강하게 눌렀을 때 + 약하게 안 눌렀을 때 + 발판에 닿았을 때(중복 선택, 연속 선택 방지)
        if (IsStrong && !IsWeak && IsPutButton)
        {
            for(int i = 0; i < 2; i++)
            {
                
                JumpCount++; //점프 횟수 증가
                UpNum++; //발판 개수 증가
                //해당 발판 위치로 플레이어 옮김                
                Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
                GroundList[UpNum].transform.position.y+3, GroundList[UpNum].transform.position.z);

                if (JumpCount >= 2) //발판을 두 번 밟으면
                {
                    JumpCount = 0; //점프 횟수를 초기화
                    IsStrong = false; //강하게 누른 것이 풀림
                }
            }
        }

        //약하게 눌렀을 때 + 강하게 안 눌렀을 때 + 발판에 닿았을 때(중복 선택, 연속 선택 방지)
        if (IsWeak && !IsStrong && IsPutButton)
        {
            JumpCount++;
            UpNum++;
            Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
            GroundList[UpNum].transform.position.y + 3, GroundList[UpNum].transform.position.z);

            if (JumpCount >= 1)
            {
                JumpCount = 0;
                IsWeak = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") //플레이어가 Ground 태그와 충돌하면
        {
            Debug.Log("태그됨");
            IsPutButton = true;
        }
        else
        {
            IsPutButton = false;
        }
    }

    //발판 클론 생성시키는 함수
    void GroundInit()
    {
        for(int i = 0; i < 10; i++)
        {
            //클론이 될 오브젝트, 생성 위치, 생성 회전 방향(사원수의 값), 부모의 설정
            GameObject _obj = Instantiate(Ground, firstground.transform.position, firstground.transform.rotation) as GameObject;
            _obj.transform.localScale = new Vector3(2f, 2f, 2f); //콜론 크기 변경

            GroundList.Add(_obj); //클론 i 만큼 생성 (현재 i는 총 10개, 즉 10개 클론 생성) 후 리스트에 인덱스 번호 줌

            //클론 위치 변경
            if (i % 2 == 0) //i가 짝수일 경우 왼쪽에 생성
            {
                GroundList[i].transform.position = new Vector3(firstground.transform.position.x,
                firstground.transform.position.y + 15f * i, transform.position.z);
            }
            else //i가 홀수일 경우 오른쪽에 생성
            {
                GroundList[i].transform.position = new Vector3(firstground.transform.position.x + 20f,
                firstground.transform.position.y + 15f * i, transform.position.z);
            }
        }
    }

    //https://hyunity3d.tistory.com/395
    //void MakeBoard()
    //{
    //    //가장 최근의 발판과 spPoint와의 거리 구하기
    //    if (spPoint.position.y - newBoard.position.y >= 5)
    //    {
    //        float x = Random.Range(-10f, 10f) * 0.6f;//좌 우 랜덤 생성
    //        Vector3 pos = new Vector3(x, spPoint.position.y, 0.3f);
    //        newBoard = Instantiate(boardPrefab, pos, Quaternion.identity) as Transform;
    //    }
    //}
}
