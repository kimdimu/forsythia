using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class ObjectPosition : MonoBehaviour
{

    public float FirstTime; //전체시간
    public float LimitTime; //변동시간

    //가지 오브젝트
    public GameObject BranchObject1; //일반가지
    public GameObject BranchObject2; //나뭇잎
    public GameObject BranchObject3; //꽃
    public GameObject BranchObject4; //시든가지

    public GameObject BranchFly; //도약발판

    //가지를 랜덤으로 생성할 오브젝트
    public GameObject RandomBranch_Right; //오른쪽
    public GameObject RandomBranch_Left; //왼쪽

    //가지의 right오브젝트의 위치값을 넣어줄 벡터
    private Vector3 RightBranchPos;

    //가지의 left오브젝트의 위치값을 넣어줄 벡터
    private Vector3 LeftBranchPos;

    //기둥의 회전 x값을 조정하는 변수
    int RandQNum;

    //클론을 생성할 초기기둥 오브젝트
    public GameObject Branch1;

    //기둥객체를 생성하고 관리해줄 리스트 생성
    List<GameObject> branchList = new List<GameObject>();

    //GameObject TEST = GameObject.FindGameObjectWithTag("test");

    //위치값을 받아올 기둥 빈오브젝트
    public GameObject emptybranch1;

    //기둥의 빈오브젝트의 위치값을 넣어줄 벡터
    private Vector3 lastBranchPos;

    // 가지종류전환을 위한 랜덤값생성위한 인티져값
    int RandBranchIndex;

    // 가지예외체크를 위한 이전가지의 종류값받아올 변수
    int PreNum = 7;

    bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        //코루틴함수 호출
        StartCoroutine(BranchRandomGenerator());

        //벡터에 기둥의 빈오브젝트의 위치값을 넣어준다
        lastBranchPos = this.emptybranch1.transform.position;

  

        //벡터에 가지의 오른쪽 빈오브젝트의 위치값을 넣어준다
        RightBranchPos = this.RandomBranch_Right.transform.position;

        //벡터에 가지의 왼쪽 빈오브젝트의 위치값을 넣어준다
        LeftBranchPos = this.RandomBranch_Right.transform.position;



    }

    void Update()
    {       
        LimitTime -= Time.deltaTime; // 일정한 시간에 따라 감소

        Debug.Log("제한시간 : " + LimitTime);

    }

    //========================기둥, 가지 생성부=========================//
    IEnumerator BranchRandomGenerator()
    {
        //가지를 랜덤으로 생성할 배열
        GameObject[] BranchArray = new GameObject[4];


        //배열에 오브젝트들을 넣어줌
        BranchArray[0] = BranchObject1;
        BranchArray[1] = BranchObject2;
        BranchArray[2] = BranchObject3;
        BranchArray[3] = BranchObject4;



        //스케일을 변환시켜준다.
        BranchObject1.transform.localScale = new Vector3(1148.665f, 615.4145f, 295.8598f);
        BranchObject2.transform.localScale = new Vector3(1148.665f, 615.4145f, 295.8598f);
        BranchObject3.transform.localScale = new Vector3(1148.665f, 615.4145f, 295.8598f);
        BranchObject4.transform.localScale = new Vector3(1148.665f, 615.4145f, 295.8598f);

        BranchFly.transform.localScale = new Vector3(2, 2, 2);

        //=================================================// 

        //pos1과 pos2 ,pos3를 벡터로 선언
        Vector3 pos1, pos2, pos3;

        while (true) //나중에 조건식같은거를 넣어서 줄기생기는 갯수를 통제하도록 하자
        {


            //줄기의 쿼터니온을 조절 (270이 수직으로서는 각도 왼쪽으로 25도, 오른쪽으로 25도 하여 총 50도로 조절)
            RandQNum = Random.Range(245, 295); //245 ~ 295 랜덤으로 숫자 생성


            //emptybranch1.transform.position = Branch1.transform.position; // 초기기둥의 위치를 빈오브젝트의 위치로 넣음

            // pos1 = this.emptybranch1.transform.position; //빈오브젝트의 위치 = pos1


            // << 처음 : 빈오브젝트의 위치>> 
            // << while 문 한번 돌고 : 리스트의 마지막에 있는 클론의 0,1,2번째 자식위치값>> 을 받은 벡터를 넣어준다.
            pos1 = lastBranchPos;
            pos2 = RightBranchPos;
            pos3 = LeftBranchPos;

            //가지생성방향 전환을 위한 랜덤값 생성
            int ChangeDir = Random.Range(0, 2);

            // 가지종류전환을 위한 랜덤값생성
            // 예외 : 1번이 생성된다음 2번나올수 없고, 2번 다음 2번 나올수 없고,  2번 다음 1번 나올수 없다.



            bool checkCreate = false;

            if (LimitTime < 0)
                test = true;


            for (int i = 0; i < 1; i++)
            {
                if (LimitTime >= 0)
                {
                    /*==========================오른쪽에 가지생성=========================*/
                    if (ChangeDir == 0 && checkCreate == false)
                    {

                        //만약 이전에 시든가지가 생성되었었다면
                        if (PreNum == 3 && checkCreate == false)
                        {
                            //랜덤값을 다시 계산하고
                            RandBranchIndex = Random.Range(0, 2);
                            //Debug.Log("가지번호 : " + RandBranchIndex);
                            //배열0~1까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos2.x, pos2.y, pos2.z), Quaternion.Euler(0f, 90f, 0f));
                            checkCreate = true;
                        }

                        //이전가지가 꽃가지도 시든가지도 아니었다면
                        else if (PreNum != 2 && PreNum != 3 && checkCreate == false)
                        {
                            RandBranchIndex = Random.Range(0, 4);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~3까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos2.x, pos2.y, pos2.z), Quaternion.Euler(0f, 90f, 0f));
                            checkCreate = true;
                        }




                        //만약 이전에 꽃가지가 생성되었었다면
                        if (PreNum == 2 && checkCreate == false)
                        {
                            //랜덤값을 다시 계산하고
                            RandBranchIndex = Random.Range(0, 3);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~2까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos2.x, pos2.y, pos2.z), Quaternion.Euler(0f, 90f, 0f));
                            checkCreate = true;
                        }

                        //이전가지가 꽃가지가 아니었다면
                        else if (PreNum != 2 && checkCreate == false)
                        {
                            RandBranchIndex = Random.Range(0, 4);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~3까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos2.x, pos2.y, pos2.z), Quaternion.Euler(0f, 90f, 0f));
                            checkCreate = true;
                        }

                    }

                    /*==========================왼쪽에 가지생성=========================*/
                    if (ChangeDir == 1 && checkCreate == false)
                    {
                        //만약 이전에 시든가지가 생성되었었다면
                        if (PreNum == 3 && checkCreate == false)
                        {
                            //랜덤값을 다시 계산하고
                            RandBranchIndex = Random.Range(0, 2);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~1까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos3.x, pos3.y, pos3.z), Quaternion.Euler(-180f, 90f, 0f));
                            checkCreate = true;
                        }

                        //이전가지가 꽃가지도 시든가지도 아니었다면
                        else if (PreNum != 2 && PreNum != 3 && checkCreate == false)
                        {
                            RandBranchIndex = Random.Range(0, 4);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~3까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos3.x, pos3.y, pos3.z), Quaternion.Euler(-180f, 90f, 0f));
                            checkCreate = true;
                        }




                        //만약 이전에 꽃가지가 생성되었었다면
                        if (PreNum == 2 && checkCreate == false)
                        {
                            //랜덤값을 다시 계산하고
                            RandBranchIndex = Random.Range(0, 3);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~2까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos3.x, pos3.y, pos3.z), Quaternion.Euler(-180f, 90f, 0f));
                            checkCreate = true;
                        }

                        //이전가지가 꽃가지가 아니었다면
                        else if (PreNum != 2 && checkCreate == false)
                        {
                            RandBranchIndex = Random.Range(0, 4);
                            //Debug.Log("가지번호 : " + RandBranchIndex);

                            //배열0~3까지의 오브젝트를 랜덤생성한다. 위치는 RightBranchPos위치 
                            Instantiate(BranchArray[RandBranchIndex], new Vector3(pos3.x, pos3.y, pos3.z), Quaternion.Euler(-180f, 90f, 0f));
                            checkCreate = true;
                        }

                    }
                }

                else if (test == true)
                {
                    //도약발판한번만 생성되게 만들ㅇ어야함.
                    Instantiate(BranchFly, new Vector3(pos3.x, pos3.y, pos3.z), Quaternion.Euler(-180f, 90f, 0f));
                    test = false;
                }


                //기둥 오브젝트를 빈오브젝트 위치에 로테이션 x는 랜덤으로 y = 90 z = -90으로 생성하고
                GameObject _obj = Instantiate(Branch1, new Vector3(pos1.x, pos1.y, pos1.z), Quaternion.Euler(RandQNum, 90f, -90f)) as GameObject;

                PreNum = RandBranchIndex;

                //Debug.Log("저장된 가지번호 : " + PreNum);

                // 생성된 오브젝트를 branchlist 에 add로 추가.
                branchList.Add(_obj);

                



            }

            //리스트의 마지막에 있는 클론의 0번째 자식위치값을 lastBranchPos에 받아옴
            lastBranchPos = branchList[branchList.Count - 1].transform.GetChild(0).transform.position;

            //리스트의 마지막에 있는 클론의 1번째 자식위치값을 RightBranchPos에 받아옴
            RightBranchPos = branchList[branchList.Count - 1].transform.GetChild(1).transform.position;

            //리스트의 마지막에 있는 클론의 2번째 자식위치값을 RightBranchPos에 받아옴
            LeftBranchPos = branchList[branchList.Count - 1].transform.GetChild(2).transform.position;

            //GameObject lastBranch = branchList[branchList.Count - 1];
            //lastBranch.transform.GetChild(0);


            //0.5f초후에 다시 while문 돈다.
            yield return new WaitForSeconds(0.5f);



        }
    }
}

