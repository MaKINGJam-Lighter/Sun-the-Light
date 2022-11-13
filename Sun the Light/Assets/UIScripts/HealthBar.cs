using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;
    public float damage;
    public GameManager gameManager;
    public SceneController sceneController;

    // Update is called once per frame
    void Update()
    {
        //안된다.
        //체력 다 깎이면 남은 체력 안 보이게
        if (healthBar.value <= 0)
        {
            healthBar.gameObject.SetActive(false);
            if (gameManager.score >= 30000)
                PlayerPrefs.SetInt("ClearStage", 3);
            else if(gameManager.score >= 10000)
                PlayerPrefs.SetInt("ClearStage", 2);
            else
                PlayerPrefs.SetInt("ClearStage", 1);

            PlayerPrefs.SetFloat("MaxScore", gameManager.maxScore);
            sceneController.GoOverGame();
        }
    }

}
