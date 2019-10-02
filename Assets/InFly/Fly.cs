using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player; //움직일 오브젝트
    public Rigidbody _player;

    float _Time;
    //public static float GetSpeedTime;

    void Start()
    {
        _player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //GetSpeedTime += Time.deltaTime; //일정한 시간에 따라 증가함

        //시작하고 3초동안은 빠르게 나아간다
        //if(GetSpeedTime >= 0 && GetSpeedTime <= 3.0f)
        //{
        //    plyer.transform.position += Vector3.forward * 100 * Time.deltaTime;
        //}
    }
    //오른쪽으로 버튼을 누르면
    public void RightFly()
    {
        if (TestFly.right)
        {
            Debug.Log("오른쪽");
            //_player.AddForce(new Vector3(player.transform.position.x, player.transform.position.y,
            //    player.transform.position.z * TestFly.MoveSpeed));
            _player.AddForce(Vector3.right * TestFly.MoveSpeed);
            //_player.AddForce(Vector3.right * TestFly.MoveSpeed);
            //player.transform.position += Vector3.left * TestFly.MoveSpeed * Time.deltaTime;
        }
    }
    //왼쪽으로 버튼을 누르면
    public void LeftFly()
    {
        if (TestFly.left)
        {
            Debug.Log("왼쪽");
            //_player.AddForce(new Vector3(player.transform.position.x, player.transform.position.y,
            //    player.transform.position.z * -1 * TestFly.MoveSpeed));
            _player.AddForce(Vector3.left * TestFly.MoveSpeed);
            //_player.AddForce(Vector3.left * TestFly.MoveSpeed);
            //player.transform.position += Vector3.left * TestFly.MoveSpeed * Time.deltaTime;
        }
    }
    //버튼 누르는 동안
    public void OnPointerDown(PointerEventData eventData)
    {
        TestFly.right = true;
        TestFly.left = true;
    }
    //버튼에서 손을 떼면
    public void OnPointerUp(PointerEventData eventData)
    {
        TestFly.right = false;
        TestFly.left = false;
    }
}
