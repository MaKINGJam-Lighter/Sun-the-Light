using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public bool isBGM=false;
    public bool isEffect=false;

    private AudioSource music;

    private void Start()
    {
        music = this.GetComponent<AudioSource>();
        //슬라이더의 값을 볼륨 값으로 바꾼다. 
        if(isBGM) 
        {
            music.volume = DontDestroy.sliderValue_bgm;
            print(music.volume);
        }
        if(isEffect)
        {
            music.volume = DontDestroy.sliderValue_effect;
        }
    }

}