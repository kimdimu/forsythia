using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCon : MonoBehaviour
{
    public GameObject PausePanel;

    bool isActive; // 판넬끄고켜기

    void Awake()
    {

    }

    void Start()
    {
        isActive = false;
        PausePanel.SetActive(false);
    }

    public void _PauseButton()
    {
        Invoke("PauseButtonClick", .4f);
    }

    void PauseButtonClick()
    {
        if(isActive == false)
        {
            //Time.timeScale = 0f; //일시정지
            PausePanel.SetActive(true);
            isActive = true;

        }
    }


    public void _ToMainBotton()
    {
        //Time.timeScale = 1f; //일시정지해제
        Invoke("ToMainClick", .4f);
    }


    void ToMainClick()
    {
        SceneManager.LoadScene("TestMain");
    }


    public void _ContinueButton()
    {
        Invoke("ContinueClick", .4f);
    }

    void ContinueClick()
    {
        if (isActive == true)
        {
            //Time.timeScale = 1f; //일시정지해제
            PausePanel.SetActive(false);
            isActive = false;
            Debug.Log("check");

        }
    }
}


