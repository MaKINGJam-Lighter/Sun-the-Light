using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmounts : MonoBehaviour
{
    public Image img_Skill;

    void Update()
    {
        //스킬버튼누르면
        if (Input.GetKeyDown(KeyCode.T))
        {
            //인자: 쿨타임 초
            StartCoroutine(CoolTime(13f));
        }    
    }

    IEnumerator CoolTime(float cool)
    {
        print("쿨타임 코루틴 실행");

        while (cool >1.0f)
        {
            //이거하는동안 클릭 못하게

            cool -= Time.deltaTime;
            img_Skill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }

        print("쿨타임 코루틴 완료");
    }
}
