using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : Level
{
    private float[] timeArr = { 0.3f, 2f };
    private int[] obstacleIndexArr = { 0, 9 };
    private float[] angleArr = { -30f, 30f };
    private float[] speedArr = { 5f, 10f };

    override public void SetLevel()
    {
        CreateObstacle createObstacle = GameObject.Find("ObstacleManager").GetComponent<CreateObstacle>();
        createObstacle.timeArr = timeArr;
        createObstacle.obstacleIndexArr = obstacleIndexArr;
        createObstacle.angleArr = angleArr;
        createObstacle.speedArr = speedArr;
    }
}
