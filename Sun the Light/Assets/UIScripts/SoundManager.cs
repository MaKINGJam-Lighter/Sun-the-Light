﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    //public static GameObject main;
    private float bgmValue;
    private float effectValue;
    private bool wholeBgm;
    private bool wholeEffect;

    public bool isBgm;
    public bool isEffect;
    
    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
       
        //사운드
        this.effectValue = SliderScript.EffectValue;
        this.bgmValue = SliderScript.BgmValue;
        
        //전체사운드
        this.wholeEffect = WholeSoundButtonEvent.Effect;
        this.wholeBgm = WholeSoundButtonEvent.Bgm;
      
        //오디오소스 가져오기
        music=this.gameObject.GetComponent<AudioSource>();

        if (isBgm)
        {
           
           
            if (wholeBgm == false)
            {
                music.volume = 0f;
            }
            else
                music.volume = bgmValue;
        }
        else if (isEffect)
        {
            if (wholeEffect == false)
            {
                music.volume = 0f;
            }
            else
                music.volume = effectValue;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            //사운드
            this.effectValue = SliderScript.EffectValue;
            this.bgmValue = SliderScript.BgmValue;
            //전체사운드
            this.wholeEffect = WholeSoundButtonEvent.Effect;
            this.wholeBgm = WholeSoundButtonEvent.Bgm;

            if (isBgm)
            {
                if (wholeBgm==false)
                {
                    music.volume = 0f;
                }
                else 
                    music.volume = bgmValue;
            }
            else if (isEffect)
            {
                if (wholeEffect==false)
                {
                    music.volume = 0f;
                }
                else
                    music.volume = effectValue;
            }
        }
    }
}
