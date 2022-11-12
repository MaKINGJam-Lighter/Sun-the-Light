using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject PlayerFireFowardPrefab;
    public GameObject PlayerFireBackwardPrefab;
    public GameObject FireSkillPrefab;

    GameObject[] PlayerFire;
    GameObject[] PlayerFireBackward;
    GameObject[] FireSkill;

    void Awake()
    {
        PlayerFire = new GameObject[100];
        PlayerFireBackward = new GameObject[100];
        FireSkill = new GameObject[100];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < PlayerFire.Length; i++)
        {
            PlayerFire[i] = Instantiate(PlayerFireFowardPrefab);
            PlayerFire[i].SetActive(false);
        }
        for (int i = 0; i < PlayerFireBackward.Length; i++)
        {
            PlayerFireBackward[i] = Instantiate(PlayerFireBackwardPrefab);
            PlayerFireBackward[i].SetActive(false);
        }
        for (int i = 0; i < FireSkill.Length; i++)
        {
            FireSkill[i] = Instantiate(FireSkillPrefab);
            FireSkill[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "PlayerFire":
                for(int i = 0; i < PlayerFire.Length; i++)
                {
                    if (!PlayerFire[i].activeSelf)
                    {
                        PlayerFire[i].SetActive(true);
                        return PlayerFire[i];
                    }
                }
                break;
            case "PlayerFireBackward":
                for (int i = 0; i < PlayerFireBackward.Length; i++)
                {
                    if (!PlayerFireBackward[i].activeSelf)
                    {
                        PlayerFireBackward[i].SetActive(true);
                        return PlayerFireBackward[i];
                    }
                }
                break;
            case "FireSkill":
                for (int i = 0; i < FireSkill.Length; i++)
                {
                    if (!FireSkill[i].activeSelf)
                    {
                        FireSkill[i].SetActive(true);
                        return FireSkill[i];
                    }
                }
                break;
        }
        return null;
    }
}
