using System.Collections;
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

    void Start()
    {
        _CameraBut = CameraBtn.transform.position; //원래 위치 저장
        newCameraBut = new Vector3(-100, 100, 0); //새로운 위치 지정
        CameraPanmel.SetActive(false);     
    }

    void Update()
    {
        if (ButtonMa.IsCameraClick) //카메라 눌렀으면
        {
            OptionBtn.SetActive(false); //설정 버튼 안 보이게 함
            MissionBtn.SetActive(false); //미션 버튼 안 보이게 함
            CameraBtn.transform.position = newCameraBut; //새로운 위치로 이동시킴
            CameraPanmel.SetActive(true); //카메라 팝업 보이게 함
            Controller.SetActive(false); //컨트롤러 보이게 함
        }

        if (!ButtonMa.IsCameraClick) //카메라 안 눌렀으면
        {
            OptionBtn.SetActive(true); //설정 버튼 보이게함
            MissionBtn.SetActive(true); //미션 버튼 보이게 함
            CameraBtn.transform.position = _CameraBut; //원래 위치로 돌아옴
            CameraPanmel.SetActive(false); //카메라 팝업 안 보이게 함
            Controller.SetActive(true); //컨트롤러 안 보이게 함
        }
    }
}
