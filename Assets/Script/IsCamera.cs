﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCamera : MonoBehaviour
{
    public GameObject OptionBtn;
    public GameObject CameraBtn;
    public GameObject MissionBtn;
    public GameObject CameraPanmel;
    public GameObject Controller;

    Vector3 _CameraBut; //카메라 버튼의 원래 위치
    Vector3 newCameraBut; //카메라 버튼의 새로운 위치

    Vector3 _CameraPan; //카메라 판넬의 원래 위치
    Vector3 newCameraPan; //카메라 판넬의 새로운 위치

    void Start()
    {
        _CameraBut = CameraBtn.transform.position; //원래 위치 저장
        newCameraBut = new Vector3(-100, 100, 0); //새로운 위치 지정

        _CameraPan = CameraPanmel.transform.position; //원래 위치 저장
        newCameraPan = new Vector3(-500, 500, 0); //새로운 위치 지정   
    }

    void Update()
    {
        if (ButtonMa.IsCameraClick) //카메라 눌렀으면
        {
            Debug.Log("카메라 누름 / 코루틴 전 위치 : "+ CameraPanmel.transform.position);
            OptionBtn.SetActive(false); //설정 버튼 안 보이게 함
            MissionBtn.SetActive(false); //미션 버튼 안 보이게 함
            CameraBtn.transform.position = newCameraBut; //새로운 위치로 이동시킴 (안 보이게 함)
            Controller.SetActive(false); //컨트롤러 안 보이게 함

            StartCoroutine("Rendering");

            Debug.Log("카메라 누름 / 코루틴 후 위치 : " + CameraPanmel.transform.position);
        }

        if (!ButtonMa.IsCameraClick) //카메라 안 눌렀으면
        {
            OptionBtn.SetActive(true); //설정 버튼 보이게 함
            MissionBtn.SetActive(true); //미션 버튼 보이게 함
            CameraBtn.transform.position = _CameraBut; //원래 위치로 돌아옴 (보이게 함)
            CameraPanmel.transform.position = newCameraPan; //새로운 위치로 이동시킴 (안 보이게 함)
            Controller.SetActive(true); //컨트롤러 보이게 함
        }
    }

    IEnumerator Rendering()
    {
        yield return new WaitForEndOfFrame();

        byte[] imgBytes;
        string path = @"C:\Users\403\Documents\GitHub\forsythia\ScreenShot\test.png";
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();

        imgBytes = texture.EncodeToJPG();
        System.IO.File.WriteAllBytes(path, imgBytes);
        Debug.Log(path + " has been saved");

       // yield return new WaitForSeconds(0.1f);

        CameraPanmel.transform.position = _CameraPan; //원래 위치로 돌아옴 (보이게 함)
    }
}
