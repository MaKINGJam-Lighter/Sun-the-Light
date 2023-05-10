using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private GameObject[] createPoints;

    private bool canCreate = true;
    private float time;
    private int obstacleIndex;
    private float angle;
    private float speed;
    private float direction;
    private float newdirection;

    public float[] timeArr;
    public int[] obstacleIndexArr;
    public float[] angleArr;
    public float[] speedArr;
    //public float[] directionArr = { -1, 1};

    private float score;

    // Start is called before the first frame update
    void Start()
    {
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (canCreate)
        {
            Invoke("Create", time);
            canCreate = false;
        }
    }

    private void Create()
    {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score; //점수 불러옴(몇 레벨인지 확인 위해) 
        // 랜덤 값 설정
        if(score < 3000)  //번개 나오면 안됨
        {
            obstacleIndex = Random.Range(0, 6);
        }
        else
        {
            obstacleIndex = Random.Range(0, 8)%8;
            //obstacleIndex = Random.Range(obstacleIndexArr[0], obstacleIndexArr[1]) % 8;
        }
        //Debug.Log(obstacleIndex);  //왜 범위를 넘는지.. .
        //obstacleIndex = Random.Range(0, 8);
        if (obstacleIndex == 6 || obstacleIndex == 7)
        {
            angle = 0;
            speed = 0;
            direction = 0;
        }
        else
        {
            angle = Random.Range(angleArr[0], angleArr[1]);
            speed = Random.Range(speedArr[0], speedArr[1]);
            direction = Random.Range(0, 12);
        }

        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex%8]);

        if (obstacleIndex == 6 || obstacleIndex == 7)
        {
            float randomX = Random.Range(-7.5f, 7.5f);
            obstacle.transform.position = new Vector3 (randomX, 0, 0);
        }
        else
        {
            if(score < 3000)   //레벨 1, 2
            {
                if (direction %2 == 1)
                {
                    obstacle.transform.position = createPoints[0].transform.position;
                    newdirection = 1;
                }
                else
                {
                    obstacle.transform.position = createPoints[1].transform.position;
                    newdirection = -1;
                }
            }
            else if(score>=3000 && score <5000)  //레벨 3
            {
                if(direction%3 == 0)
                {
                    obstacle.transform.position = createPoints[0].transform.position;
                    newdirection = 1;
                }
                else if(direction %3 == 1)
                {
                    obstacle.transform.position = createPoints[1].transform.position;
                    newdirection = -1;
                }
                else
                {
                    obstacle.transform.position = createPoints[3].transform.position;
                    newdirection = -1;
                }
            }
            else if(score>=5000 && score < 7000) //레벨 4
            {
                if (direction % 3 == 0)
                {
                    Debug.Log("생성");
                    obstacle.transform.position = createPoints[0].transform.position;
                    newdirection = 1;
                }
                else if (direction % 3 == 1)
                {
                    obstacle.transform.position = createPoints[1].transform.position;
                    newdirection = -1;
                }
                else
                {
                    obstacle.transform.position = createPoints[2].transform.position;
                    newdirection = 1;
                }
            }
            else if (score >= 7000)
            {
                if (direction % 4 == 0)
                {
                    Debug.Log("생성");
                    obstacle.transform.position = createPoints[0].transform.position;
                    newdirection = 1;
                }
                else if (direction % 4 == 1)
                {
                    obstacle.transform.position = createPoints[1].transform.position;
                    newdirection = -1;
                }
                else if(direction % 4 == 2)
                {
                    obstacle.transform.position = createPoints[2].transform.position;
                    newdirection = 1;
                }
                else
                {
                    obstacle.transform.position = createPoints[3].transform.position;
                    newdirection = -1;
                }
            }

            
        }
        obstacle.GetComponent<MoveObstacle>().SetOption(angle, speed, newdirection);

        time = Random.Range(timeArr[0], timeArr[1]);
        canCreate = true;
    }
}
