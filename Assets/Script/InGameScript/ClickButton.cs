using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
    public GameObject target;

    public static bool IsStrong = false; //강하게를 눌렀는지
    public static bool IsWeak = false; //약하게를 눌렀는지
    public static bool IsLeftJump = false; //왼쪽 도약 키를 눌렀는지
    public static bool IsRightJump = false; //오른쪽 도약 키를 눌렀는지
    public static bool IsStop = false; //옵션을 눌렀는지

    public static bool isFIrstJump = true;

    public void Strong()
    {
       IsStrong = true;

    }

    public void Weak()
    {
        IsWeak = true;




    }

    public void LeftJump()
    {
       IsLeftJump = true;
    }

    public void RightJump()
    {
       IsRightJump = true;
    }

    public void TimeNotMove()
    {
        if (IsStop)
            IsStop = false;
        else if (!IsStop)
            IsStop = true;
    }

    public void IsMain()
    {
        SceneManager.LoadScene("TestMain");
    }

    public void Again()
    {
        SceneManager.LoadScene("TestInGame");
    }
}
