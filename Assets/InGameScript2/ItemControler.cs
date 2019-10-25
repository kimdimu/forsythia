using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControler : MonoBehaviour
{
    public GameObject Shield;

    public GameObject branch_normal1;
    public GameObject normal_empty1;

    public GameObject branch_normal2;
    public GameObject normal_empty2;
    
    public GameObject branch_leaf1;
    public GameObject leaf_empty1;

    public GameObject branch_leaf2;
    public GameObject leaf_empty2;

    public GameObject branch_forsy1;
    public GameObject forsy_empty1;

    public GameObject branch_forsy2;
    public GameObject forsy_empty2;

    public GameObject branch_break;
    public GameObject break_empty;

    Vector3[] testPos = new Vector3[7];

    // 랜덤값생성위한 인티져값
    int RandItemIndex;
    int emptyRand;

    bool isItemCreate = false;

    //아이템을 생성, 관리할 리스트 생성
    List<GameObject> ItemList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {



        //리스트의 마지막에 있는 클론의 0번째 자식위치값을 testPos에 받아옴
        for(int i =0; i < 7;i++)
        {
            testPos[i] = ObjectPosition.leafList[ObjectPosition.leafList.Count - 1].transform.GetChild(0).transform.position;
        }


        testPos[0] = this.normal_empty1.transform.position;
        testPos[1] = this.normal_empty2.transform.position;
        testPos[2] = this.leaf_empty1.transform.position;
        testPos[3] = this.leaf_empty2.transform.position;
        testPos[4] = this.forsy_empty1.transform.position;
        testPos[5] = this.forsy_empty2.transform.position;
        testPos[6] = this.break_empty.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        //코루틴함수 호출
        StartCoroutine(ItemRandomGenerator());
    }

    IEnumerator ItemRandomGenerator()
    {
        //아이템을 랜덤으로 생성할 배열
        GameObject[] ITemArray = new GameObject[1];

        ITemArray[0] = Shield;


        ITemArray[0].transform.localScale = new Vector3(122.3006f, 119.6194f, 103.9678f);

        while (true)
        {
            RandItemIndex = Random.Range(0, 100); //0~99까지 90개 생성
            emptyRand = Random.Range(0, 7); //0~6

            if (RandItemIndex % 3 == 0) //34개
            {
                if (RandItemIndex > 10) //0 ,3, 6, 9 제외하면 30%확률
                {
                    Debug.Log("Check create item");
                    GameObject _ITem = Instantiate(ITemArray[0], new Vector3(testPos[emptyRand].x, testPos[emptyRand].y, testPos[emptyRand].z), Quaternion.Euler(0, 0, 0)) as GameObject;
                    ItemList.Add(_ITem);                       

                }
            }

            //else
            //{
            //    Debug.Log("Check create item!!!!!!!!!!!!!!!!!!!!");
            //}


            //0.5f초후에 다시 while문 돈다.
            yield return new WaitForSeconds(0.5f);

        }
    }
}
