using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePlayer : MonoBehaviour
{
    public GameObject _Player; //InGame의 player

    public bool IsStrong = false; //강하게를 눌렀는지
    public bool IsWeak = false; //약하게를 눌렀는지
    bool IsPutButton = false; //버튼 누를 수 있는지 없는지
    bool IsFullUp = false; //도약 도중 누를 수 없게 할 때 쓰임
    public bool IsLeftJump = false; //왼쪽 도약 키를 눌렀는지
    public bool IsRightJump = false; //오른쪽 도약 키를 눌렀는지

    int JumpCount = 0; //점프 횟수 카운트
    int UpNum = 0; //밟은 발판 개수 카운트

    public GameObject Ground; //복제 될 물체
    List<GameObject> GroundList = new List<GameObject>(); //오브젝트 리스트 생성

    GameObject firstground; //처음 발판의 위치 (발판이 생성될 위치)

    GameObject _obj; //생성된 클론

    public GameObject BirdJump; //도약 슬라이더
    public GameObject Handle; //선택 바 (움직이는 바)

    Vector3 StartPosition; //선택 바 시작 위치
    public Vector3 EndPosition; //선택 바 끝나는 위치

    public float speed; //선택 바 움직이는 스피드

    int WangBog = 0; //영역 벗어난 횟수 카운트

    public GameObject LeftJump; //왼쪽 도약 키
    public GameObject RightJump; //오른쪽 도약 키

    int ran; //랜덤 생성되는 발판의 개수 저장

    void Start()
    {
        //bool형 false로 초기화
        IsStrong = false;
        IsWeak = false;
        IsPutButton = false;
        IsFullUp = false;
        IsLeftJump = false;
        IsRightJump = false;

        LeftJump.SetActive(false); //왼쪽 도약 안보이게함
        RightJump.SetActive(false); //오른쪽 도약 안보이게함
        BirdJump.SetActive(false); //도약 바 안보이게함
        
        StartPosition = Handle.transform.position;//시작위치
        firstground = GameObject.FindGameObjectWithTag("Finish"); //처음 발판의 위치 받아오기 위해 사용
        
        GroundInit(); //발판 클론 생성
    }

    void Update()
    {
        //강하게 눌렀을 때 + 약하게 안 눌렀을 때 + 발판에 닿았을 때 + 도약중이 아닐 때 (중복, 연속, 도중 선택 방지)
        if (IsStrong && !IsWeak && IsPutButton && !IsFullUp)
        { 
            //클론이 하나 남았는데 강하게를 누를 수 없도록 하기 위함
            //남은 클론이 하나 이하일 때 강하게를 누르면
            if (ran - 1 < UpNum)
            {
                IsWeak = true; //약하게가 실행되도록 한다
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    JumpCount++; //점프 횟수 증가
                                 //해당 발판 위치로 플레이어 옮김. y + 3 한 이유 : 플레이어가 발판 사이에 끼여서 조금 띄움
                    _Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
                    GroundList[UpNum].transform.position.y + 3, GroundList[UpNum].transform.position.z);
                    UpNum++; //발판 개수 증가

                    if (JumpCount >= 2) //발판을 두 번 밟으면
                    {
                        JumpCount = 0; //점프 횟수를 초기화
                        IsStrong = false; //강하게 누른 것이 풀림
                    }
                }
            }
        }
       
        //약하게 눌렀을 때 + 강하게 안 눌렀을 때 + 발판에 닿았을 때 + 도약중이 아닐 때 (중복, 연속, 도중 선택 방지)
        if (IsWeak && !IsStrong && IsPutButton && !IsFullUp)
        {
            JumpCount++;
            _Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
            GroundList[UpNum].transform.position.y + 3, GroundList[UpNum].transform.position.z);
            UpNum++;

            if (JumpCount >= 1)
            {
                JumpCount = 0;
                IsWeak = false;
            }
        }

        if(UpNum >= ran) //끝에 다다르면
        {
            IsFullUp = true; //도약중으로 바꿈

            LeftJump.SetActive(true); //왼쪽 도약 보이게함
            RightJump.SetActive(true); //오른쪽 도약 보이게함
            BirdJump.SetActive(true); //도약 바 보이게함

            /* _StartPosition.x = 480, _EndPosition.x = 480
            //오른쪽 도약 키, 왼쪽 도약 키를 같이 눌렀으면
            if(IsRightJump && IsLeftJump)
            {
                //성공 영역에서 눌렀으면
                if(Handle.transform.position.x >= StartPosition.x && Handle.transform.position.x <= 410 ||
                Handle.transform.position.x >= 580 && Handle.transform.position.x <= EndPosition.x)
                {

                }
                //대성공 영역에서 눌렀으면
                if(Handle.transform.position.x >= 410 && Handle.transform.position.x <= 580)
                {

                }
            }*/
            //선택 바의 좌표가 끝나는 좌표보다 크거나 같으면 또는 선택 바의 좌표가 시작 좌표보다 작으면 (빨간 영역 넘어가면)
            if (Handle.transform.position.x >= EndPosition.x || Handle.transform.position.x < StartPosition.x)
            {
                //(+)인 스피드에 (-)를 곱하여 (-)로 바꿔 왼쪽(<-)으로 움직이게 함
                //(-)인 스피드에 (-)를 곱하여 (+)로 바꿔 오른쪽(->)으로 움직이게 함
                speed = speed * (-1.0f);
               // WangBog++; //벗어난 영역 횟수 증가
            }
            //선택 바 위치 움직이기
            Handle.transform.position = new Vector3(Handle.transform.position.x + speed, Handle.transform.position.y, 0);

            if (WangBog == 4) //영역 네 번 벗어나면 = 왕복 두 번
            {
                Destroy(_obj.gameObject); //클론 삭제

                UpNum = 0; //발판 밟은 개수 초기화
                LeftJump.SetActive(false); //왼쪽 도약 안보이게함
                RightJump.SetActive(false); //오른쪽 도약 안보이게함
                BirdJump.SetActive(false); //도약 바 안보이게함
                WangBog = 0; //벗어난 영역 횟수 초기화
                IsFullUp = false; //도중 선택 가능하게 바꿈
                //도약중일 땐 못누르게 했는데 왜 눌려져서 true로 바뀌어지는지 모르겠다
                IsStrong = false;
                IsWeak = false;

                //처음 발판의 위치로 플레이어 옮김
                // Player.transform.position = new Vector3(Ground.transform.position.x,
                //Ground.transform.position.y + 3, Ground.transform.position.z);

                //TestFly 씬으로 가 비행을 시작한다
                SceneManager.LoadScene("TestFly");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") //플레이어가 Ground 태그와 충돌하면
        {
            IsPutButton = true; //버튼 누를 수 있음
        }
        else
        {
            IsPutButton = false; //버튼 누를 수 없음
        }
    }

    //발판 클론 생성시키는 함수
    void GroundInit()
    {
        ran = Random.Range(10, 30);
        
        for (int i = 0; i < ran; i++)
        {
            //클론이 될 오브젝트, 생성 위치, 생성 회전 방향(사원수의 값), 부모의 설정
            _obj = (GameObject)Instantiate(Ground, firstground.transform.position, firstground.transform.rotation);
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
}
