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

        //체력 다 깎이면 남은 체력 안 보이게
        if (healthBar.value <= 0)
        {

            healthBar.transform.Find("Fill Area").gameObject.SetActive(false);
            if (gameManager.isZeusKilled)
            {
                PlayerPrefs.SetInt("ClearStage", 5);
            }
            else if (gameManager.score >= 7000 && gameManager.isApolloKilled)
            {
                PlayerPrefs.SetInt("ClearStage", 4);
            }
            else if (gameManager.score >= 3000 && gameManager.isApolloKilled)
            {
                PlayerPrefs.SetInt("ClearStage", 3);
            }
            else if(gameManager.score >= 3000)
            {
                PlayerPrefs.SetInt("ClearStage", 2);
            }
            else
            {
                PlayerPrefs.SetInt("ClearStage", 1);
            }

            PlayerPrefs.SetString("MaxScore", gameManager.maxScore.ToString());

            if (PlayerPrefs.GetInt("ClearStage") == 5)
            {
                sceneController.GoClearGame();
            }
            else
            {
                sceneController.GoOverGame();
            }
        }
    }

}
