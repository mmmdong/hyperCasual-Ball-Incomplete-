using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //움직임 관련
    public float patternSpeed;
    float time;

    private bool isDead;

    private void Start()
    {
        patternSpeed = 1.0f;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else instance = null;
    }
    private void Update()
    {
        PatternMoveControl();
    }


    //일반 함수 private
    private void PatternMoveControl()
    {
        time += Time.deltaTime;
        if (time >= 25.0f)
        {
            patternSpeed += 0.5f;
            time = 0.0f;
        }
        if (patternSpeed >= 3.0f)
        {
            patternSpeed = 3.0f;
        }
    }
    
    
    
    //반환형 함수 public
    public bool GameOver()
    {
        isDead = true;
        Debug.Log("으앙~ 듀금ㅠㅠ");
        Debug.Log(isDead);
        return isDead;
    }
    public float Speed()
    {
        return patternSpeed;
    }
}
