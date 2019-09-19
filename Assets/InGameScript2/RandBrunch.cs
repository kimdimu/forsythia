using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class RandBrunch : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    int positionCon = 0;



    void Start()
    {
        StartCoroutine(ObjectRandomGenerator());
    }

    IEnumerator ObjectRandomGenerator()
    {
        GameObject[] tempGO = new GameObject[4];

        tempGO[0] = object1;
        tempGO[1] = object2;
        tempGO[2] = object3;
        tempGO[3] = object4;

        object1.transform.localScale = new Vector3(1044.595f, 539.7225f, 539.7225f);
        object2.transform.localScale = new Vector3(809.9556f, 367.082f, 491.3162f);
        object3.transform.localScale = new Vector3(1.904798f, 74.37221f, 4.96139f);
        object4.transform.localScale = new Vector3(1206.267f, 367.082f, 491.3162f);


        while (positionCon <= 350)
        {
            Instantiate(tempGO[Random.Range(0, 4)], new Vector3(759.55f, 1190f + positionCon/*이전에 생긴 발판의 y좌표값보다 -0.0364 만큼*/, 0f), Quaternion.Euler(0f, 90f, 0f));
            //object1 Quaternion -> /*Quaternion.Euler(-15.899f, 87.616f, -91.47301f)*/
            Instantiate(tempGO[Random.Range(0, 4)], new Vector3(756.5f, 1214.8f + positionCon/*이전에 생긴 발판의 y좌표값보다 -0.0364 만큼*/, 0f), Quaternion.Euler(0f, -90f, 0f));

            yield return new WaitForSeconds(0.1f);

            positionCon += 50;

            Debug.Log(positionCon);

        }
    }
}
