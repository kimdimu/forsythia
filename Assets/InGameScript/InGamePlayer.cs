using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayer : MonoBehaviour
{
    public Rigidbody Player; //FreezePosition 사용 위해 선언

    public bool IsStrong = false; //강하게를 눌렀는지
    public bool IsWeak = false; //약하게를 눌렀는지

    int JumpCount = 0; //점프 횟수 카운트

    Vector3 StartPosition; //캐릭터의 처음 위치 저장

    //public Transform boardPrefab; //프리팹
    //public Transform newBoard; //프리팹으로 생성된 오브젝트 저장 변수

    public GameObject Ground; //발판 물체(오브젝트)
    Vector3 GroundPosition; //발판 위치 저장

    bool IsGround = false; //발판을 밟았는지

    void Start()
    {
        IsStrong = false;
        IsWeak = false;
        IsGround = false;

        StartPosition = transform.position; //캐릭터의 처음 위치 저장
        GroundPosition = Ground.transform.position; //발판의 위치 저장

        Player = GetComponent<Rigidbody>(); //FreezePosition 사용 위해 선언
    }

    void Update()
    {
        //강하게 눌렀을 때 + 약하게 안 눌렀을 때 (중복 선택 방지)
        if(IsStrong && !IsWeak)
        {
            for(int i = 0; i < 2; i++)
            {
                JumpCount++; //점프 횟수 증가
                //발판 중심으로 플레이어 위치 옮김 / y에 + 4한 이유 : 상자가 발판 사이에 끼여있어서 y 좌표를 올려주었다
                //옮겨지는 모습 안보임, 해당 위치에 이미 가 있음
                transform.position = new Vector3(GroundPosition.x, GroundPosition.y+4, GroundPosition.z);
                IsGround = true; //현재 발판을 밟고 있습니다

                if (JumpCount >= 2) //발판을 두 번 밟으면
                {
                    JumpCount = 0; //점프 횟수를 초기화
                    IsStrong = false; //강하게 누른 것이 풀림
                    IsGround = false; //축 고정 해제
                }
            }
        }

        //약하게 눌렀을 때 + 강하게 안 눌렀을 때 (중복 선택 방지)
        if (IsWeak && !IsStrong)
        {
            JumpCount++;
            transform.position = new Vector3(GroundPosition.x, GroundPosition.y+4, GroundPosition.z);
            IsGround = true;

            if (JumpCount >= 1)
            {
                JumpCount = 0;
                IsWeak = false;
                IsGround = false;
            }
        }

        if(IsGround == true)
        {
            //튕기지 않도록 x, y, z축 고정
            Player.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    void OnTriggerEnter(Collider ground)
    {
        if(ground.tag == "Ground") //Ground 태그와 충돌하면
        {
            //현재 밟고 있는 발판을 제외한 가장 가까운 발판의 위치(아래 있는 발판 제외)가 GroundPosition이 된다

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
