using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeEffect : MonoBehaviour
{

    Text tx;
    bool done = false;
    private string Msg = "";
    public GameObject next;

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
            //끝나면 점수화면으로
            else
            {
                
                SceneManager.LoadScene("MainGame");
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