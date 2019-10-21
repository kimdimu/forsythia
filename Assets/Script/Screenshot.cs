using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public GameObject CameraPanel;

    Vector3 _CameraBut; //카메라 판넬의 원래 위치
    Vector3 newCameraBut; //카메라 판넬의 새로운 위치

    void Start()
    {
        _CameraBut = CameraPanel.transform.position; //원래 위치 저장
        newCameraBut = new Vector3(-100, 100, 0); //새로운 위치 지정
    }

    public void IsCapture()
    {
        CameraPanel.transform.position = newCameraBut; //새로운 위치로 이동시킴
        StartCoroutine("Rendering"); //코루틴 함수 돌림
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

        CameraPanel.transform.position = _CameraBut; //원래 위치로 돌아옴
    }
}
