using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed; //플레이어의 이동 속도
    public float gravity;
    public float maxShotDelay;   //불 발사 속도 조절할 딜레이 변수
    public float currentShotDelay;

    private bool isEnterTop;   //각 4방향 경계에 접촉?되었는지 여부 체크할 변수
    private bool isEnterBottom;
    private bool isEnterLeft;
    private bool isEnterRight;

    public GameObject fire_foward;
    public GameObject fire_backward;
    public GameObject fire_skill;
    

    Animator bigWheelAnim;  //나중에 애니메이션 위해서
    Animator smallWheelAnim;
    Animator horseAnim;
    Rigidbody2D player;

    public float curTime;
    public float coolTime;
    public Image skillCoolImg;

    private bool isFire=true;

    void Awake()
    {
        bigWheelAnim = gameObject.transform.GetChild(3).GetComponent<Animator>();
        smallWheelAnim = gameObject.transform.GetChild(4).GetComponent<Animator>();
        horseAnim = gameObject.transform.GetChild(1).GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        curTime = coolTime;
        bigWheelAnim.SetBool("isMoving", true);
        smallWheelAnim.SetBool("isMoving", true);
        horseAnim.SetBool("isRunning", true);
        //player.AddForce(Vector2.down * gravity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.velocity = Vector2.down * gravity;


    }

    void Update()
    {
        Move();
        Fire(); //총알 발사
        FireSkill();
        Reload();
    }


    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isEnterRight && h == 1) || (isEnterLeft && h == -1))
        {
            h = 0;
            
        }

        float v = Input.GetAxisRaw("Vertical");
        if ((isEnterTop && v == 1) || (isEnterBottom && v == -1))
        {
            v = 0;
            
        }

        Vector3 currentPosition = transform.position;
        Vector3 nextPosition = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = currentPosition + nextPosition;

        //if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        //{
            //bigWheelAnim.SetBool("isMoving", true);
            //smallWheelAnim.SetBool("isMoving", true);
        //}
        //else
        //{
            //bigWheelAnim.SetBool("isMoving", false);
            //smallWheelAnim.SetBool("isMoving", false);
       // }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bottom")
        {
            isEnterBottom = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bottom")
        {
            isEnterBottom = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border") //경계 만나면
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isEnterTop = true;
                    break;
                case "Bottom":
                    isEnterBottom = true;
                    break;
                case "Left":
                    isEnterLeft = true;
                    break;
                case "Right":
                    isEnterRight = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border") //경계 만나면
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isEnterTop = false;
                    break;
                case "Bottom":
                    isEnterBottom = false;
                    break;
                case "Left":
                    isEnterLeft = false;
                    break;
                case "Right":
                    isEnterRight = false;
                    break;
            }
        }
    }


    void Fire()
    {
        if (currentShotDelay < maxShotDelay)
        {
            return;
        }

        if (Input.GetButton("FireFoward"))   //전방공격: a키
        {
            if (!Input.GetButton("FireFoward")) return;
            Vector3 firePos = transform.position + new Vector3(0, -0.5f, 0);
            GameObject fire = Instantiate(fire_foward, firePos, transform.rotation);
            Rigidbody2D rigid = fire.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        }
        else if (Input.GetButton("FireBackward")) //후방공격: d키
        {
            if (!Input.GetButton("FireBackward")) return;
            Vector3 firePos = transform.position + new Vector3(0, -0.5f, 0);
            GameObject fire = Instantiate(fire_backward, firePos, transform.rotation);
            Rigidbody2D rigid = fire.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
        }

        currentShotDelay = 0;
    }

    void Reload()
    {
        currentShotDelay += Time.deltaTime;
    }

    void FireSkill()  //스킬 버튼 누르면 원모양으로 불이 퍼져나감 
    {
        if (Input.GetKeyDown(KeyCode.S) && isFire)
        {
            Debug.Log("s키 누름");
            //if (isFire)
            //{
                int roundNumA = 25;
                for (int i = 0; i < roundNumA; i++)
                {
                    GameObject fireObj = Instantiate(fire_skill, transform.position, Quaternion.identity);
                    Rigidbody2D rigid = fireObj.GetComponent<Rigidbody2D>();
                    Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / roundNumA),
                                     Mathf.Sin(Mathf.PI * 2 * i / roundNumA));  //원 형태로 발사
                    rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

                }
                isFire = false;
                Debug.Log("스킬 써짐");
                //isFire = false;
            //}

        }
        if (!isFire)  //쿨타임 아직 안찼을때만 쿨타임 감소시킴
        {
            cooltime();
        }
    }


    void cooltime()
    {
        if (curTime > 0)
        {
            curTime -= Time.deltaTime;
        }
        else //curTime <= 0
        {
            curTime = 13.0f;
            skillCoolImg.fillAmount = 1.0f;
            isFire = true;
        }
    }

}

