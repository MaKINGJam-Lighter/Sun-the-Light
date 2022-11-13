using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmounts : MonoBehaviour
{
    public Image img_Skill;
    private bool isSkill = true;
    //bool isIng;//하는중이면

    void Update()
    {
        //스킬버튼누르기
        //T버튼 눌렸고&& 스킬 쿨타임도 돌아온 상태일때만
        if (Input.GetKeyDown(KeyCode.S)&& img_Skill.fillAmount==1.0f)
        {
            if (isSkill)
            {
                StartCoroutine(CoolTime(13.0f));
                isSkill = true;
            }
            
            //인자: 쿨타임 초
            
        }    
    }

    IEnumerator CoolTime(float cool)
    {
        isSkill = false;
        while (cool > 0.0f)
        {
            //이거하는동안 클릭 못하게
            
            cool -= Time.deltaTime;
            img_Skill.fillAmount = (13.0f - cool) / 13.0f;
            yield return new WaitForFixedUpdate();
        }
        
    }
}
