using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApolloSkill : MonoBehaviour
{
    public GameObject bignote;
    public GameObject smallnote1;
    public GameObject smallnote2;
    public GameObject smallnote3;

    private GameObject note;
    private GameObject basic;

    private bool isFire = true;
    private bool isBasicSkill = true;
    private void Update()
    {
        if (isBasicSkill)
        {
            float time = Random.Range(3f, 5f);
            Invoke("BasicSkill", time);
            isBasicSkill = false;
        }

        if (isFire)
        {
            float time = Random.Range(2f, 4f);
            Invoke("NoteSkill", time);
            isFire = false;
        }
    }
    void BasicSkill()
    {
        float rand = Random.Range(-1f, 3f);
        Vector3 basicPos = transform.position + new Vector3(0, rand, 0);
        //int rand_skillnum = Random.Range(1, 4);  //
        //float rand_rotate = Random.Range(-45f, 45f);
        //Debug.Log(rand_rotate);
        //switch (rand_skillnum)
        //{
            //case 1:
                basic = Instantiate(smallnote1, basicPos, transform.rotation);
                //break;
            //case 2:
               // basic = Instantiate(smallnote2, basicPos, Quaternion.Euler(rand_rotate, 0, 0));
               // break;
            //case 3:
               // basic = Instantiate(smallnote3, basicPos, Quaternion.Euler(rand_rotate, 0, 0));
                //break;
        //}
        Rigidbody2D basicRigid = basic.GetComponent<Rigidbody2D>();
        basicRigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
        isBasicSkill = true;
    }
    void NoteSkill()   
    {
        Vector3 notePos = transform.position + new Vector3(0, 1f, 0);
        note = Instantiate(bignote, notePos, transform.rotation);
        Rigidbody2D rigid = note.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
        Invoke("smallNote", 0.5f);
    }
    void smallNote()
    {
        Vector3 snotePos1 = note.transform.position + new Vector3(0, 0, 0);
        Vector3 snotePos2 = note.transform.position + new Vector3(0, 0, 0);
        Vector3 snotePos3 = note.transform.position + new Vector3(0, 0, 0);
        Quaternion rot = note.transform.rotation;

        Destroy(note);
        GameObject snote1 = Instantiate(smallnote1, snotePos1, rot);
        GameObject snote2 = Instantiate(smallnote2, snotePos2, rot);
        GameObject snote3 = Instantiate(smallnote3, snotePos3, rot);
        Debug.Log("음표 분리");

        Rigidbody2D srigid1 = snote1.GetComponent<Rigidbody2D>();
        srigid1.AddForce(new Vector2(-8,6), ForceMode2D.Impulse);

        Rigidbody2D srigid2 = snote2.GetComponent<Rigidbody2D>();
        srigid2.AddForce(Vector2.left * 10, ForceMode2D.Impulse);

        Rigidbody2D srigid3 = snote3.GetComponent<Rigidbody2D>();
        srigid3.AddForce(new Vector2(-8,-6), ForceMode2D.Impulse);
        isFire = true;
    }
}
