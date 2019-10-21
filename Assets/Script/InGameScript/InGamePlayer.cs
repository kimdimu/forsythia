using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGamePlayer : MonoBehaviour
{
    public GameObject _Player; //InGame의 player

    public GameObject StrongBtn; //강하게 버튼
    public GameObject WeakBtn; //약하게 버튼

    Vector3 StVector; //st위치
    Vector3 WeVector; //we위치
    Vector3 TempVector; //위치 저장할 변수

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

    public static bool BigSuccess; //대성공
    public static bool Success; //성공

    public GameObject StopPanel; //설정 팝업

    public static int Score; //점수
    public Text Text_Score; //점수 표시 물체

    void Start()
    {
        ClickButton.IsStrong = false;
        ClickButton.IsWeak = false;
        ClickButton.IsLeftJump = false;
        ClickButton.IsRightJump = false;
        BigSuccess = false;
        Success = false;

        LeftJump.SetActive(false); //왼쪽 도약 안 보이게함
        RightJump.SetActive(false); //오른쪽 도약 안 보이게함
        BirdJump.SetActive(false); //도약 바 안 보이게함
        StopPanel.SetActive(false); //옵션 창 안 보이게 함

        StartPosition = Handle.transform.position;//시작위치
        firstground = GameObject.FindGameObjectWithTag("Ground"); //처음 발판의 위치 받아오기 위해 사용

        GroundInit(); //발판 클론 생성

        if (ChangeButton.IsChange) //자리 바뀌었으면
        {
            TempVector = StrongBtn.transform.position; //st위치를 temp에 저장
            StrongBtn.transform.position = WeakBtn.transform.position; //we위치를 st에 넣음 
            WeakBtn.transform.position = TempVector; //temp위치를 we에 저장
        }
    }

    void Update()
    {

        Text_Score.text = "점수 : " + Score;
        
        //강하게 눌렀을 때 + 약하게 안 눌렀을 때 + 두 칸 다 올라왔으면
        if (ClickButton.IsStrong && ClickButton.IsWeak == false && JumpCount == 0)
        {
            //클론이 하나 남았는데 강하게를 누를 수 없도록 하기 위한 방법 필요할듯
            StartCoroutine("Sleep"); //한 칸 올리고 해당 초동안 멈추고 한 칸 더 올리기
        }
       
        //약하게 눌렀을 때 + 강하게 안 눌렀을 때 + 발판에 닿았을 때
        if (ClickButton.IsWeak && ClickButton.IsStrong == false)
        {
            JumpCount++;
            UpNum++;
            _Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
            GroundList[UpNum].transform.position.y + 3, GroundList[UpNum].transform.position.z);

            if (JumpCount >= 1)
            {
                JumpCount = 0;
                ClickButton.IsWeak = false;
            }
        }

        if(UpNum + 1 >= ran) //끝에 다다르면
        {
            StrongBtn.SetActive(false); //강하게 키 안보이게함
            WeakBtn.SetActive(false); //약하게 키 안보이게함

            LeftJump.SetActive(true); //왼쪽 도약 보이게함
            RightJump.SetActive(true); //오른쪽 도약 보이게함
            BirdJump.SetActive(true); //도약 바 보이게함

            /* 대성공_StartPosition.x = 140, 대성공_EndPosition.x = 170,
             성공_StartPosition.x = 100, 성공_EndPosition.x = 205
            //오른쪽 도약 키, 왼쪽 도약 키를 같이 눌렀으면
            if(IsRightJump && IsLeftJump)
            {
                //실패 영역에서 눌렀으면
                if(Handle.transform.position.x >= StartPosition.x && Handle.transform.position.x <= 100) ||
                Handle.transform.position.x >= 205 && Handle.transform.position.x <= EndPosition.x))
                {
                    //게임 종료
                }
                //성공 영역에서 눌렀으면
                if((Handle.transform.position.x >= 47 && Handle.transform.position.x <= 140) ||
                (Handle.transform.position.x >= 170 && Handle.transform.position.x <= 270))
                {
                    SceneManager.LoadScene("TestFly"); //Fly 시작
                    Success = true;
                }
                //대성공 영역에서 눌렀으면
                if(Handle.transform.position.x >= 140 && Handle.transform.position.x <= 170)
                {
                    SceneManager.LoadScene("TestFly");
                    BigSuccess = true;
                }
            }
            //오른쪽 도약 키, 왼쪽 도약 키를 같이 안 눌렀으면
            if((IsRightJump && !IsLeftJump) || (!IsRightJump && IsLeftJump))
            {
                //게임 종료
            }*/
            //선택 바의 좌표가 끝나는 좌표보다 크거나 같으면 또는 선택 바의 좌표가 시작 좌표보다 작으면 (빨간 영역 넘어가면)
            if (Handle.transform.position.x >= EndPosition.x || Handle.transform.position.x < StartPosition.x)
            {
                //(+)인 스피드에 (-)를 곱하여 (-)로 바꿔 왼쪽(<-)으로 움직이게 함
                //(-)인 스피드에 (-)를 곱하여 (+)로 바꿔 오른쪽(->)으로 움직이게 함
                speed = speed * (-1.0f);
                WangBog++; //벗어난 영역 횟수 증가
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

                //TestFly 씬으로 가 비행을 시작한다
                SceneManager.LoadScene("TestFly");
            }
        }
        if (ClickButton.IsStop) //옵션을 눌러 켜졌으면
        {
            Time.timeScale = 0; //시간 멈춤
            StopPanel.SetActive(true); //옵션 판넬 보이게 함
        }
        if (!ClickButton.IsStop) //옵션을 눌러 꺼졌으면
        {
            Time.timeScale = 1; //시간 움직임
            StopPanel.SetActive(false); //옵션 판넬 안보이게 함
        }
    }

    IEnumerator Sleep()
    {
        JumpCount++; //점프 횟수 증가
        UpNum++; //발판 개수 증가
        //해당 발판 위치로 플레이어 옮김. y + 3 한 이유 : 플레이어가 발판 사이에 끼여서 조금 띄움
        _Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
                                        GroundList[UpNum].transform.position.y + 3, GroundList[UpNum].transform.position.z);
        yield return new WaitForSeconds(0.3f); //0.3초간 멈춤
        JumpCount++;
        UpNum++;
        _Player.transform.position = new Vector3(GroundList[UpNum].transform.position.x,
                                        GroundList[UpNum].transform.position.y + 3, GroundList[UpNum].transform.position.z);
        if (JumpCount == 2) //발판을 두 번 밟으면
        {
            ClickButton.IsStrong = false; //강하게 누른 것이 풀림
            JumpCount = 0; //점프 횟수를 초기화
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
                GroundList[i].transform.position = new Vector3(firstground.transform.position.x + 20f,
                firstground.transform.position.y + 15f * i, transform.position.z);
            }
            else //i가 홀수일 경우 오른쪽에 생성
            {
                GroundList[i].transform.position = new Vector3(firstground.transform.position.x,
                firstground.transform.position.y + 15f * i, transform.position.z);
            }
        }
    }
}
