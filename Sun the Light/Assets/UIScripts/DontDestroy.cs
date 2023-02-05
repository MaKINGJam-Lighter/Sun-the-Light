using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    public static GameObject BGMSlider;
    public static GameObject EffectSlider;
    public static GameObject main;//싱글톤
    private int sceneIncex;
    public static int isOnce=1;//스택x
    public static float sliderValue_bgm;
    public static float sliderValue_effect;
    public GameObject BGMObject;
    private static Slider BGMComponent;
    public GameObject EffectObject;
    private static Slider EffectComponent;

    // Start is called before the first frame update
    void Start()
    {
        if (isOnce == 1)
        {
            main = this.gameObject;//자기참조
            BGMSlider = BGMObject;
            EffectSlider = EffectObject;
            DontDestroyOnLoad(main);
            DontDestroyOnLoad(BGMSlider);
            DontDestroyOnLoad(EffectSlider);
        }
        //print(isOnce);
        sceneIncex = SceneManager.GetActiveScene().buildIndex;
        //print("현재 씬: " + sceneIncex);
        BGMComponent = BGMObject.GetComponent<Slider>();
        EffectComponent = EffectObject.GetComponent<Slider>();

        sliderValue_bgm = BGMComponent.value;
        sliderValue_effect = EffectComponent.value;
        isOnce++;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex==0)
        {
            //main.SetActive(true);
            //슬라이더값 static으로 저장
            sliderValue_bgm = BGMComponent.value;
            sliderValue_effect = EffectComponent.value;
            //print("현재 씬: " + sceneIncex);
            print(sliderValue_bgm);
        }
        else  //홈 씬이 아니면
        {
            main.SetActive(false);
            print(sliderValue_bgm);
        }
            
    }
}
