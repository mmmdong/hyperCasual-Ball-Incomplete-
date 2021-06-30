using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D squAre;
    //public float speed;
    //private float accel;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        squAre = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        //speed = 1.0f;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        squAre.isTrigger = true;
    }

    private void Update()
    {
        //accel += Time.deltaTime;
        transform.position -= new Vector3(0, GameManager.instance.Speed() * Time.deltaTime, 0);
        //if (accel >= 1)
        //{ 
        //    speed += 0.5f;
        //    accel = 0;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //speed = 0;
        //accel = 0;
        squAre.isTrigger = false;
        rigid.bodyType = RigidbodyType2D.Dynamic;
        rigid.gravityScale = 0.5f;
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
