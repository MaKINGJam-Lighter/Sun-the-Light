using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool isPause;
    public Image pauseImage;

    void Start()
    {
        isPause = false;    
    }

    // Update is called once per frame
    void Update()
    {
        //엔터버튼 누르면 일시정지
        if(Input.GetKeyDown(KeyCode.Return)) {
            //일시정지 활성화
            if (isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                pauseImage.gameObject.SetActive(true);
                return;
            }
            //일시정지 비활성화
        if (isPause == true)
        {
            Time.timeScale = 1;
            isPause= false;
            pauseImage.gameObject.SetActive(false);
            return;
        }
    }
        }

        
}
