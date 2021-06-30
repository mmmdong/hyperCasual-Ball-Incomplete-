using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Circle")||
            collision.gameObject.CompareTag("Square"))
        {
            GameManager.instance.GameOver();
        }
    }
}
