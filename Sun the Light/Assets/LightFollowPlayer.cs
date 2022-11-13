using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowPlayer : MonoBehaviour
{

    Player player;
    Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        diff = transform.position - player.transform.position;
    }

    //빛이 오른쪽 밑으로
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + diff; ;
    }
}
