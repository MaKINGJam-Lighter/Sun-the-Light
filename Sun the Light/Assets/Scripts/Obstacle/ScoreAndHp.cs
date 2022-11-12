using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndHp : MonoBehaviour
{
    [SerializeField]
    private float score;

    [SerializeField]
    private float hp;

    public float GetScore()
    {
        return score;
    }

    public float GetHp()
    {
        return hp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyObstacle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "character")
        {
            DestroyObstacle();
            DecreaseHP();
        }
        else if(collision.tag == "bullet")
        {
            DestroyObstacle();
            IncreaseScore();
        }
    }

    private void DestroyObstacle()
    {
        gameObject.GetComponent<Animator>().SetBool("isDestroy", true);
    }

    private void DecreaseHP()
    {
        // HP 값을 가져와 적용 
    }

    private void IncreaseScore()
    {
        // 스코어 값을 가져와 적용
    }
}
