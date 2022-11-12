using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //플레이어의 이동 속도

    public bool isEnterTop;   //각 4방향 경계에 접촉?되었는지 여부 체크할 변수
    public bool isEnterBottom;
    public bool isEnterLeft;
    public bool isEnterRight;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isEnterRight && h == 1) || (isEnterLeft && h == -1)){
            h = 0;
        }

        float v = Input.GetAxisRaw("Vertical");
        if ((isEnterTop && v == 1) || (isEnterBottom && v == -1))
        {
            v = 0;
        }

        Vector3 currentPosition = transform.position;
        Vector3 nextPosition = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = currentPosition + nextPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border") //경계 만나면
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isEnterTop = true;
                    break;
                case "Bottom":
                    isEnterBottom = true;
                    break;
                case "Left":
                    isEnterLeft = true;
                    break;
                case "Right":
                    isEnterRight = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border") //경계 만나면
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isEnterTop = false;
                    break;
                case "Bottom":
                    isEnterBottom = false;
                    break;
                case "Left":
                    isEnterLeft = false;
                    break;
                case "Right":
                    isEnterRight = false;
                    break;
            }
        }
    }
}
