using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderScript : MonoBehaviour
{
    Slider slider;
    public static float BgmValue=100;
    public static float EffectValue=100;

    // Start is called before the first frame update
    void Start()
    {
        slider=this.GetComponent<Slider>();


        if (this.gameObject.name == "BackgroundSlider")
        {
            slider.value = BgmValue;
        }
        else if (this.gameObject.name == "EffectSlider")
        {
            slider.value = EffectValue;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0)
        {
            this.transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
            this.transform.Find("Fill Area").gameObject.SetActive(true);


        if(this.gameObject.name== "BackgroundSlider")
        {
            BgmValue = slider.value;
        }
        else if(this.gameObject.name == "EffectSlider")
        {
            EffectValue = slider.value;
        }
        
    }
}
