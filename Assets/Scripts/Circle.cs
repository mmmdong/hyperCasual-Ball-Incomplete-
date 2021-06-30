using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    Rigidbody2D rigid;
    CircleCollider2D cirCle;
    //public float speed;
    //private float accel;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cirCle = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        //speed = 1.0f;
        rigid.bodyType = RigidbodyType2D.Kinematic;
        cirCle.isTrigger = true;
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
        rigid.bodyType = RigidbodyType2D.Dynamic;
        rigid.gravityScale = 0.5f;

        cirCle.isTrigger = false;

        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
