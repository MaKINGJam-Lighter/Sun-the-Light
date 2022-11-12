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

    public float[] timeArr;
    public int[] obstacleIndexArr;
    public float[] angleArr;
    public float[] speedArr;
    public float[] directionArr = { -1, 1};

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
        // 랜덤 값 설정
        obstacleIndex = Random.Range(obstacleIndexArr[0], obstacleIndexArr[1]);
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
            direction = directionArr[Random.Range(0, 2)];
        }

        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex]);

        if (obstacleIndex == 6 || obstacleIndex == 7)
        {
            float randomX = Random.Range(-7.5f, 7.5f);
            obstacle.transform.position = new Vector3 (randomX, 0, 0);
        }
        else
        {
            if (direction == 1)
            {
                obstacle.transform.position = createPoints[0].transform.position;
            }
            else
            {
                obstacle.transform.position = createPoints[1].transform.position;
            }
        }
        obstacle.GetComponent<MoveObstacle>().SetOption(angle, speed, direction);

        time = Random.Range(timeArr[0], timeArr[1]);
        canCreate = true;
    }
}
