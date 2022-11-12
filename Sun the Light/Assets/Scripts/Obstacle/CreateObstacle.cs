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
    private float[] directionArr = { -1, 1};

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
        obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        angle = Random.Range(-20f, 20f);
        speed = Random.Range(2f, 6f);
        direction = directionArr[Random.Range(0, 2)];

        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex]);
        if(direction == 1)
        {
            obstacle.transform.position = createPoints[0].transform.position;
        }
        else
        {
            obstacle.transform.position = createPoints[1].transform.position;
        }
        obstacle.GetComponent<MoveObstacle>().SetOption(angle, speed, direction);

        time = Random.Range(1f, 6f);
        canCreate = true;
    }
}
