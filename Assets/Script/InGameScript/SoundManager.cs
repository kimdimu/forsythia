using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    bool IsBOff;
    bool IsBOn;
    public GameObject BSoundOff;
    public GameObject BSoundOn;
    public AudioSource BackAudio;

    //bool IsEOff;
    //bool IsEOn;
    //public GameObject ESoundOff;
    //public GameObject ESoundOn;
    //public AudioSource EffectAudio;

    void Start()
    {
        //배경음과 효과음은 켜져 있는 것으로 시작됨
        IsBOff = false;
        IsBOn = true;
        //IsEOff = false;
        //IsEOn = true;
    }

    void Update()
    {
        //배경음
        if (IsBOn) //켜져있으면
        {
            BSoundOff.SetActive(false);
            BSoundOn.SetActive(true);
            BackAudio.mute = false;
        }
        if (IsBOff) //꺼져있으면
        {
            BSoundOff.SetActive(true);
            BSoundOn.SetActive(false);
            BackAudio.mute = true;
        }
        //효과음
        //if (IsEOn) //켜져있으면
        //{
        //    ESoundOff.SetActive(false);
        //    ESoundOn.SetActive(true);
        //    EffectAudio.mute = false;
        //}
        //if (IsEOff) //꺼져있으면
        //{
        //    ESoundOff.SetActive(true);
        //    ESoundOn.SetActive(false);
        //    EffectAudio.mute = true;
        //}
    }

    public void IsBackSound()
    {
        if (IsBOn)
        {
            IsBOn = false;
            IsBOff = true;
        }
        else if (IsBOff)
        {
            IsBOff = false;
            IsBOn = true;
        }
    }

    //public void IsEffectSound()
    //{
    //    if (IsEOn)
    //    {
    //        IsEOn = false;
    //        IsEOff = true;
    //    }
    //    else if (IsEOff)
    //    {
    //        IsEOff = false;
    //        IsEOn = true;
    //    }
    //}
}
