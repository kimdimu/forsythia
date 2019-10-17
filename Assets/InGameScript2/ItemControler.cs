//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ItemControler : MonoBehaviour
//{
//    public GameObject Shield;

//    public GameObject branch_normal1;
//    public GameObject empty_normal1;

//    private Vector3 testPos;

//    // 랜덤값생성위한 인티져값
//    int RandItemIndex;

//    //아이템을 생성, 관리할 리스트 생성
//    List<GameObject> ItemList = new List<GameObject>();

//    // Start is called before the first frame update
//    void Start()
//    {       
//        testPos = this.empty_normal1.transform.position;

//        //리스트의 마지막에 있는 클론의 0번째 자식위치값을 testPos에 받아옴
//        testPos = ObjectPosition.leafList[ObjectPosition.leafList.Count - 1].transform.GetChild(0).transform.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //가지를 랜덤으로 생성할 배열
//        GameObject[] ITemArray = new GameObject[1];


//        //배열에 오브젝트들을 넣어줌

//        // 노말
//        ITemArray[0] = Shield;

//        //랜덤값
//        RandItemIndex = Random.Range(0, 1);

//        int testest = Random.Range(0, 10);


//        if(testtest /3 ==0)
//        {
//            GameObject _Item = Instantiate(ITemArray[RandItemIndex], new Vector3(testPos.x, testPos.y, testPos.z), Quaternion.Euler(90, 90, 90)) as GameObject;

//        }

//        ItemList.Add(_Item);
//    }
//}
