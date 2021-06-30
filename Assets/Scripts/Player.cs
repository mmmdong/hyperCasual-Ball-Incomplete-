using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    JoyStickMovement controller;

    public float speed;
    private Vector3 direction;
    private Vector3 originPos;

    private Vector3 limPos;

    private void Awake()
    {
        controller = FindObjectOfType<JoyStickMovement>();
        speed = 5.0f;
        direction = Vector3.zero;
        originPos = new Vector3(0, -1.5f, 0);
    }

    private void Update()
    {
        PlayerLock();
        Move();
    }

    public void Move()
    {
        direction = controller.joyVec;
        
        transform.position += direction * speed * Time.deltaTime;

        if(!controller.Click())
        {
            transform.position = Vector3.MoveTowards(transform.position, originPos, speed * 1.5f * Time.deltaTime);
        }
    }

    private void PlayerLock()
    {
        limPos = Camera.main.WorldToViewportPoint(transform.position);
        
        if (limPos.x < 0f) limPos.x = 0f;
        if (limPos.x > 1f) limPos.x = 1f;
        if (limPos.y < 0f) limPos.y = 0f;
        if (limPos.y > 1f) limPos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(limPos);
    }

}
