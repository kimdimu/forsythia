using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
   // public GameObject target;
    public GameObject ClickSound; //click effect sound

    public static bool IsStrong = false; //강하게를 눌렀는지
    public static bool IsWeak = false; //약하게를 눌렀는지
    public static bool IsLeftJump = false; //왼쪽 도약 키를 눌렀는지
    public static bool IsRightJump = false; //오른쪽 도약 키를 눌렀는지
    public static bool IsStop = false; //옵션을 눌렀는지

    public void Strong()
    {
        IsStrong = true;
        AudioSource ClickSound1 = ClickSound.GetComponent<AudioSource>(); //Clik Effect Sound를 가져온다
        ClickSound1.Play(); //가져온 효과응을 실행시킨다
    }

    public void Weak()
    {
        IsWeak = true;
        AudioSource ClickSound2 = ClickSound.GetComponent<AudioSource>();
        ClickSound2.Play();
    }

    public void LeftJump()
    {
       IsLeftJump = true;
    }

    public void RightJump()
    {
       IsRightJump = true;
    }

    public void TimeNotMove() //option, Again
    {
        if (IsStop)
            IsStop = false;
        else if (!IsStop)
            IsStop = true;
    }

    public void IsMain() //gomain
    {
        SceneManager.LoadScene("TestMain"); //메인으로 돌아감
    }

    public void Replay() //replay
    {
        SceneManager.LoadScene("TestInGame"); //인게임으로 돌아감
    }
}
