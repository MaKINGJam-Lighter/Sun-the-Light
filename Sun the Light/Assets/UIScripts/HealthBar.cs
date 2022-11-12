using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;
    public float damage;
    

    // Update is called once per frame
    void Update()
    {
        //데미지입으면(if문에 넣기)
        if (Input.GetKeyDown(KeyCode.A))
        {
            healthBar.value -= damage;
        }
        //안된다.
        //체력 다 깎이면 남은 체력 안 보이게
        if (healthBar.value <= 0)
        {
           healthBar.gameObject.SetActive(false);
        }
    }

}
