using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public void IsCapture()
    {
        StartCoroutine("Rendering");
    }

    IEnumerator Rendering()
    {
        yield return new WaitForEndOfFrame();

        byte[] imgBytes;
        //string path = @"G:\SreenShot\test.png";
        string path = @"C:\Users\403\Documents\GitHub\forsythia\ScreenShot\test.png";
         Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();

        imgBytes = texture.EncodeToJPG();
        System.IO.File.WriteAllBytes(path, imgBytes);
        Debug.Log(path + " has been saved");
    }
}
