using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypingEffect : MonoBehaviour
{

    Text tx;
    bool done = false;
    private string Msg = "";
    public GameObject next;
    public GameObject restartBtn;
    //텍스트 가져오기
    //public GameObject gameOverMsg;

    void Start()
    {
        tx = GetComponent<Text>();
        Msg = tx.text;
        tx.enabled = true;
        StartCoroutine(_typing());
    }

    void Update()
    {
        if (done == true)
        {
            tx.enabled = false;
            if (next)
                next.SetActive(true);
            else//타이핑 끝나면 리스타트버튼 활성화
            {
                restartBtn.SetActive(true);
                //gameOverMsg.SetActive(true);
            }
        }
    }

    IEnumerator _typing()
    {
        for (int i = 0; i <= Msg.Length; i++)
        {
            tx.text = Msg.Substring(0, i);
            if (i == Msg.Length)
                done = true;
            yield return new WaitForSeconds(0.075f);
        }
    }

}