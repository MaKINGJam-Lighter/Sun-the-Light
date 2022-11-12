using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    private float[] timeArr = { 2f, 5f };
    private int[] obstacleIndexArr = { 0, 6};
    private float[] angleArr = { -15f, 15f};
    private float[] speedArr = { 2f, 5f };

    override public void SetLevel()
    {
        CreateObstacle createObstacle = GameObject.Find("ObstacleManager").GetComponent<CreateObstacle>();
        createObstacle.timeArr = this.timeArr;
        createObstacle.obstacleIndexArr = this.obstacleIndexArr;
        createObstacle.angleArr = this.angleArr;
        createObstacle.speedArr = this.speedArr;
    }
}
