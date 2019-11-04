//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ItemControler : MonoBehaviour
//{
//    //아이템 오브젝트
//    public GameObject Shield;
//    public GameObject superjump;
//    public GameObject booster;
//    public GameObject coin;
//    public GameObject score;
//    public GameObject flowerGarden;


//    //아이템객체를 관리할 리스트 생성
//    List<GameObject> ItemList = new List<GameObject>();

//    //아이템 종류 전환을 위한 랜덤값생성위한 인티져값
//    int RandItemIndex;

//    //아이템을 생성을 위해 가지 속의 빈오브젝트의 위치값을 넣어줄 벡터
//    private Vector3 lastItemPos;


//    // Start is called before the first frame update
//    void Start()
//    {
//        //코루틴함수 호출
//        StartCoroutine(ItemRandomGenerator());
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    IEnumerator ItemRandomGenerator()
//    {
//        //아이템을 랜덤으로 생성할 배열
//        GameObject[] ItemArray = new GameObject[6];

//        ////////*아이템배열에 오브젝트들을 넣어줌*////////
//        ItemArray[0] = Shield;
//        ItemArray[1] = superjump;
//        ItemArray[2] = booster;
//        ItemArray[3] = coin;
//        ItemArray[4] = score;
//        ItemArray[5] = flowerGarden;


//        //스케일을 변환시켜준다.
//        Shield.transform.localScale = new Vector3(0.086578f, 20, 20);
//        superjump.transform.localScale = new Vector3(0.086578f, 20, 20);
//        booster.transform.localScale = new Vector3(0.086578f, 20, 20);
//        coin.transform.localScale = new Vector3(0.086578f, 20, 20);
//        score.transform.localScale = new Vector3(0.086578f, 20, 20);
//        flowerGarden.transform.localScale = new Vector3(0.086578f, 20, 20);

//        //제한시간이 0보다 크거나 같을때 까지만 나뭇가지생성 (기둥은 계속 생성)
//        if (ObjectPosition.LimitTime >= 0)
//        {

//            int ItemRandnum = Random.Range(1, 11); //1~10까지 랜덤숫자 생성

//            if (ItemRandnum % 3 == 0) //1~11까지 중 3으로 나누어서 나머지가 0이 나오는 수 : 3,6,9 /// 10개 중 3개 -> 30%의 확률 
//            {
//                RandItemIndex = Random.Range(0, 6); //0~5까지

//                GameObject _item = Instantiate(ItemArray[RandItemIndex], new Vector3(lastItemPos.x, lastItemPos.y + 30, lastItemPos.z), Quaternion.Euler(-0, 90, 0)) as GameObject;

//                // 생성된 오브젝트를 leafList 에 add로 추가.
//                ItemList.Add(_item);
//            }
//        }


//        //리스트의 마지막에 있는 클론의 0번째 자식위치값을 lastBranchPos에 받아옴
//        lastItemPos = ObjectPosition.leafList[ObjectPosition.leafList.Count - 1].transform.GetChild(0).transform.position;

//        //0.5f초후에 다시 while문 돈다.
//        yield return new WaitForSeconds(0.5f);
//    }


//}
