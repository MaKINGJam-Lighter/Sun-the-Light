using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField]
    private float angle;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float direction;

    public void SetOption(float angle, float speed, float direction)
    {
        this.angle = angle;
        this.speed = speed;
        this.direction = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (direction == 1)
        {
            gameObject.transform.Rotate(0, 180, angle);
        }
        else
        {
            gameObject.transform.Rotate(0, 0, angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);

        if(gameObject.transform.position.x > 20 || gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
