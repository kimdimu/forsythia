using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15;
    private Vector3 moveDir;

    //캐릭터가 움직일 스피드
    public float speed = 10.0f;

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        if (Input.GetKey(KeyCode.UpArrow)) //키보드 위쪽 화살표가 눌릴경우  

        { this.transform.Translate(Vector3.forward * speed * Time.deltaTime); }

        // this(이스크립트를 가지고있는).transform(컴포넌트).Translate(움직을 주는)값을

        // Vector3(3D 방항).forward(앞).*speed(속도).*Time.deltaTime(1초당)

        if (Input.GetKey(KeyCode.DownArrow))

        { this.transform.Translate(Vector3.back * speed * Time.deltaTime); }

        if (Input.GetKey(KeyCode.RightArrow))

        { this.transform.Translate(Vector3.right * speed * Time.deltaTime); }

        if (Input.GetKey(KeyCode.LeftArrow))

        { this.transform.Translate(Vector3.left * speed * Time.deltaTime); }
    }

    void FixedUpdate()
    {
       // rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
