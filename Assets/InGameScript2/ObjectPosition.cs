using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public GameObject emptybranch1;
    public GameObject emptybranch2;
    public GameObject emptybranch3;


    public GameObject test;

    public GameObject Branch1, Branch2, Branch3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BranchRandomGenerator());
    }




    IEnumerator   BranchRandomGenerator()
    {
        Vector3 pos1;
        Vector3 pos2;
        Vector3 pos3;
        Vector3 posTest;

        GameObject[] tempbranch = new GameObject[4];

        tempbranch[0] = emptybranch1;
        tempbranch[1] = emptybranch2;
        tempbranch[2] = emptybranch3;
        tempbranch[3] = test;

        //위치값 갱신 ->  위치값 삭제되서 안나옴 어케하면 좋을까 dnlclrkqt!!!!!!!!!!!!
        pos1 = this.emptybranch1.transform.position;
        pos2 = this.emptybranch2.transform.position;
        pos3 = this.emptybranch3.transform.position;
        posTest = this.test.transform.position;

        //Debug.Log(pos1);
        //Debug.Log(pos2);
        //Debug.Log(pos3);

        while (true)
        {
               
           // //첫번째 가지 생성
           // Instantiate(Branch1, new Vector3(posTest.x, posTest.y, posTest.z), Quaternion.Euler(270f, 90f, -90f));

           // //첫번째 가지 지움
           // Destroy(Branch1);

           // ////위치값갱신
           // // pos1 = this.emptybranch1.transform.position;



           // //2초후에
           // yield return new WaitForSeconds(2f);


           // // //첫번째 가지위에 2번째 가지 생성 악 거지같은 줄긴아ㅓ라ㅣㄴ어리ㅏㄴ엄갸 ㅓㅑㅇ너리ㅏ저ㅑㅐ러다루ㅡ
           //Instantiate(Branch2, new Vector3(pos1.x, pos1.y, pos1.z), Quaternion.Euler(-110f, 90f, -90f));

           // // //두번째 가지 지움
           // // Destroy(Branch2);


           // //Instantiate(Branch3, new Vector3(pos2.x, pos2.y, pos2.z), Quaternion.Euler(-60f, 90f, -90f));



        }


    }





}

