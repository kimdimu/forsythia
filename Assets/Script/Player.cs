using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //public float moveSpeed = 15;
    private Vector3 moveDir;
    float SwipeLength;
    Vector2 StartPos;
<<<<<<< HEAD
    Vector2 LastPos;
=======
    Vector2 LastPos;    
    public GameObject Target;
    public GameObject MainCam;
>>>>>>> parent of 702ab88... Camera2
    // SP와 LP 사이의 거리가 일정 이상일 경우 인게임 화면 
    private GameObject target;

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        //클릭 주변에 객체들을 체크 
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
            if (target.Equals(gameObject))
            {
                this.StartPos = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (target.Equals(gameObject))
            {
                this.LastPos = Input.mousePosition;
                SwipeLength = LastPos.x - StartPos.x;
            }
        }
        Debug.Log(SwipeLength);
        if(SwipeLength >= 5 || SwipeLength <= - 5)
        {
            SceneManager.LoadScene("GamePlay");

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //회전 매개변수 축, 각도, 기준점
            transform.Rotate(0, Time.deltaTime * -80, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, Time.deltaTime * 80, 0, Space.World);
        }
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

   

    void FixedUpdate()
    {
       // rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
