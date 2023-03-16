using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusSkill : MonoBehaviour
{
    public GameObject fire_skill;
    private bool isFire = true;

    private void Update()
    {
        if (isFire)
        {
            float time = Random.Range(2f, 4f);
            Invoke("FireSkill", time);
            isFire = false;
        }
    }
    void FireSkill()  //스킬 버튼 누르면 원모양으로 불이 퍼져나감 
    {

        int roundNumA = Random.Range(15, 30);


        for (int i = 0; i < roundNumA; i++)
        {
            GameObject fireObj = Instantiate(fire_skill, transform.position, Quaternion.Euler(new Vector3(0, 0, 90f + (360/roundNumA) * i)));
            Rigidbody2D rigid = fireObj.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / roundNumA),
                             Mathf.Sin(Mathf.PI * 2 * i / roundNumA));  //원 형태로 발사
            rigid.AddForce(dirVec.normalized * 6, ForceMode2D.Impulse);

        }
        isFire = true;
    }
}
