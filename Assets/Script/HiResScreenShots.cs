//using UnityEngine;
//using System.Collections;

//public class HiResScreenShots : MonoBehaviour
//{
//    private int resWidth = 1280;
//    private int resHeight = 752;

//    private bool takeHiResShot = false;

//    void Awake()
//    {
//        resWidth = Screen.width;
//        resHeight = Screen.height;
//    }

//    public static string ScreenShotName(int width, int height)
//    {
//        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
//                             Application.dataPath,
//                             width, height,
//                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
//    }

//    public void TakeHiResShot()
//    {
//        takeHiResShot = true;
//    }

//    void LateUpdate()
//    {
//        takeHiResShot |= Input.GetKeyDown("k");
//        if (takeHiResShot)
//        {
//            takeHiResShot = false;

//            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
//            //camera.targetTexture = rt;
//            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
//            //camera.Render();
//            RenderTexture.active = rt;
//            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
//            //camera.targetTexture = null;
//            RenderTexture.active = null; // JC: added to avoid errors
//            Destroy(rt);

//            // 파일로 저장.
//            byte[] bytes = screenShot.EncodeToPNG();
//            string filename = ScreenShotName(resWidth, resHeight);
//           // File.WriteAllBytes("mnt/sdcard/DCIM/Camera/number_" + Time.time.ToString() + ".png", bytes);
//            //System.IO.File.WriteAllBytes(filename, bytes);
//            Debug.Log(string.Format("Took screenshot to: {0}", filename));

//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HiResScreenShots : MonoBehaviour
{
    public Camera _camera;       //보여지는 카메라.

    private int resWidth;
    private int resHeight;
    string path;

    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
        path = Application.dataPath + "/ScreenShot/";
        Debug.Log(path);
    }

    public void ClickScreenShot()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;
        name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
       // _camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        //_camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);
    }
}