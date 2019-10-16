using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject StopPanel; //설정 팝업

    void Start()
    {
        StopPanel.SetActive(false);
    }
    
    void Update()
    {
        if (ButtonMa.OptionClick) //옵션을 눌러 켜졌으면
            StopPanel.SetActive(true); //옵션 판넬 보이게 함
        if (!ButtonMa.OptionClick) //옵션을 눌러 꺼졌으면
            StopPanel.SetActive(false); //옵션 판넬 안보이게 함
    }
}
