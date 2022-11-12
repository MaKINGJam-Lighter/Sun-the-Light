using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    private float[] timeArr = { 0.5f, 3f };
    private int[] obstacleIndexArr = { 0, 8};
    private float[] angleArr = { -25f, 25f};
    private float[] speedArr = { 4f, 8f };

    override public void SetLevel()
    {
        CreateObstacle createObstacle = GameObject.Find("ObstacleManager").GetComponent<CreateObstacle>();
        createObstacle.timeArr = timeArr;
        createObstacle.obstacleIndexArr = obstacleIndexArr;
        createObstacle.angleArr = angleArr;
        createObstacle.speedArr = speedArr;
    }
}
