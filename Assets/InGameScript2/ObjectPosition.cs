using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class ObjectPosition : MonoBehaviour

{

    int RandQNum; //가지의 회전 x값을 조정하는 변수 

    public GameObject Branch1;

    List<GameObject> branchList = new List<GameObject> (); //가지객체를 생성하고 관리해줄 리스트 생성



    public GameObject emptybranch1;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(BranchRandomGenerator());
    }


    IEnumerator BranchRandomGenerator()
    {

        Vector3 pos1, pos2;
        bool isTest = true;

        while (true)
        {

            RandQNum = Random.Range(50, 120);//220 ~ 320까지 랜덤으로 숫자 생성


            //emptybranch1.transform.position = Branch1.transform.position; // 초기기둥의 위치를 빈오브젝트의 위치로 넣음

            pos1 = this.emptybranch1.transform.position; //빈오브젝트의 위치 = pos1
            

            for (int i = 0; i < 1; i++)
            {
                if(isTest == true)
                {
                    GameObject _obj = Instantiate(Branch1, new Vector3(pos1.x , pos1.y , pos1.z), Quaternion.Euler(RandQNum, 90f, -90f)) as GameObject; //오브젝트를 생성하고
                    branchList.Add(_obj); // 생성된 오브젝트를 branchlist 에 add로 추가.

                    pos2 = branchList[i].transform.position;



                    Instantiate(Branch1, new Vector3(pos1.x + pos2.x, pos1.y + pos2.y, pos1.z), Quaternion.Euler(RandQNum, 90f, -90f));
                }

            }

            //2초후에
            yield return new WaitForSeconds(2f);



        }
    }    
}

