using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    private float[] timeArr = { 1f, 4f };
    private int[] obstacleIndexArr = { 0, 7};
    private float[] angleArr = { -20f, 20f};
    private float[] speedArr = { 3f, 6f };

    override public void SetLevel()
    {
        CreateObstacle createObstacle = GameObject.Find("ObstacleManager").GetComponent<CreateObstacle>();
        createObstacle.timeArr = this.timeArr;
        createObstacle.obstacleIndexArr = this.obstacleIndexArr;
        createObstacle.angleArr = this.angleArr;
        createObstacle.speedArr = this.speedArr;
    }
}
