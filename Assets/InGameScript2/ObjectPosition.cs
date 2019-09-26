using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class ObjectPosition : MonoBehaviour
{

    //가지 오브젝트
    public GameObject BranchObject1; //일반가지
    public GameObject BranchObject2; //꽃
    public GameObject BranchObject3; //시든가지
    public GameObject BranchObject4; //나뭇잎

    //가지를 랜덤으로 생성할 오브젝트
    public GameObject RandomBranch_Right; //오른쪽
    public GameObject RandomBranch_Left; //왼쪽


    //기둥의 회전 x값을 조정하는 변수
    int RandQNum;  

    //클론을 생성할 초기기둥 오브젝트
    public GameObject Branch1;

    //기둥객체를 생성하고 관리해줄 리스트 생성
    List<GameObject> branchList = new List<GameObject> (); 

    //GameObject TEST = GameObject.FindGameObjectWithTag("test");

    //위치값을 받아올 빈오브젝트
    public GameObject emptybranch1;

    //빈오브젝트의 위치값을 넣어줄 벡터
    private Vector3 lastBranchPos;

    // Start is called before the first frame update
    void Start()
    {
        //코루틴함수 호출
        StartCoroutine(BranchRandomGenerator());

        //벡터에 빈오브젝트의 위치값을 넣어준다
        lastBranchPos = this.emptybranch1.transform.position;
    }



    //========================기둥, 가지 생성부=========================//
    IEnumerator BranchRandomGenerator()
    {
        //========================가지 생성부=========================//
        //가지를 랜덤으로 생성할 배열
        GameObject[] BranchArray = new GameObject[4];

        BranchArray[0] = BranchObject1;
        BranchArray[1] = BranchObject2;
        BranchArray[2] = BranchObject3;
        BranchArray[3] = BranchObject4;

        //스케일을 변환시켜준다.
        BranchObject1.transform.localScale = new Vector3(1044.595f, 539.7225f, 539.7225f);
        BranchObject2.transform.localScale = new Vector3(809.9556f, 367.082f, 491.3162f);
        BranchObject3.transform.localScale = new Vector3(1.904798f, 74.37221f, 4.96139f);
        BranchObject4.transform.localScale = new Vector3(1206.267f, 367.082f, 491.3162f);

        Instantiate(BranchArray[Random.Range(0, 4)], new Vector3(759.55f, 1190f, 0f), Quaternion.Euler(0f, 90f, 0f));

        //========================기둥 생성부=========================//
        //pos1과 pos2를 벡터로 선언
        Vector3 pos1, pos2;

        while (true) //나중에 조건식같은거를 넣어서 줄기생기는 갯수를 통제하도록 하자
        {
            //220 ~ 320까지 랜덤으로 숫자 생성 //줄기의 쿼터니온을 조절
            RandQNum = Random.Range(220, 320);


            //emptybranch1.transform.position = Branch1.transform.position; // 초기기둥의 위치를 빈오브젝트의 위치로 넣음

            // pos1 = this.emptybranch1.transform.position; //빈오브젝트의 위치 = pos1


            //pos1에 <<처음 : 빈오브젝트의 위치>> 
            // <<while 문 한번 돌고 : 리스트의 마지막에 있는 클론의 0번째 자식위치값>> 을 받은 벡터를 넣어준다.
            pos1 = lastBranchPos;

            //tesT = this.TEST.transform.position;


            for (int i = 0; i < 1; i++)
            {
                //기둥 오브젝트를 빈오브젝트 위치에 로테이션 x는 랜덤으로 y = 90 z = -90으로 생성하고
                GameObject _obj = Instantiate(Branch1, new Vector3(pos1.x, pos1.y, pos1.z), Quaternion.Euler(RandQNum, 90f, -90f)) as GameObject;
                
                // 생성된 오브젝트를 branchlist 에 add로 추가.
                branchList.Add(_obj); 

                //pos2에 리스트의 클론위치값을 넣어줌
                pos2 = branchList[i].transform.position;
            }

            //리스트의 마지막에 있는 클론의 0번째 자식위치값을 lastBranchPos에 받아옴
            lastBranchPos = branchList[branchList.Count - 1].transform.GetChild(0).transform.position;



            //GameObject lastBranch = branchList[branchList.Count - 1];
            //lastBranch.transform.GetChild(0);


            //2초후에 다시 while문 돈다.
            yield return new WaitForSeconds(2f);



        }
    }    
}

