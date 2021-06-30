using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patterns : MonoBehaviour
{
    public GameObject[] preFabs;

    int patNum;
    int prefabNum;
    float interval;
    float speed;

    public int patCount;
    List<int> patList = new List<int>();

    private void Awake()
    {
        speed = 1.0f;
        //인스펙터에서 패턴 갯수를 입력할때마다 리스트에 배열 추가
        for (int i = 0; i < patCount; i++)
        {
            patList.Add(i);
        }
        patNum = Random.Range(0, patList.Count);
        prefabNum = Random.Range(0, preFabs.Length);
        //리스트를 돌려서 그 안의 인자값을 실행시킴
        Pattern(patNum, prefabNum);
    }

    private void Update()
    {
        Interval();
    }


    void Interval()
    {
        interval += Time.deltaTime;
        if (interval >= 10.0f) interval = 0.0f;
        if (interval == 0)
        {
            patNum = Random.Range(0, patList.Count);
            prefabNum = Random.Range(0, preFabs.Length);
            //리스트를 돌려서 그 안의 인자값을 실행시킴
            Pattern(patNum, prefabNum);
        }
    }

    void Pattern(int p_num, int cORs)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Vector3 position = new Vector3(transform.position.x + 0.8f * i, transform.position.y + 0.8f * j, 0);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);

                //patterns
                if (p_num == 0)
                {
                    Instantiate(preFabs[cORs], position, rotation);
                }
                else if (p_num == 1)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    Instantiate(preFabs[cORs], position, rotation);
                }
                else if (p_num == 2)
                {
                    if (i == j || i + j == 5)
                    {
                        continue;
                    }
                    Instantiate(preFabs[cORs], position, rotation);
                }
                else if (p_num == 3)
                {
                    if (i + j == 2 || i - j == 3 || j - i == 3 || i + j == 8)
                    {
                        continue;
                    }
                    Instantiate(preFabs[cORs], position, rotation);
                }
                else if (p_num == 4)
                {
                    if (i == 2 || i == 3)
                    {
                        continue;
                    }
                    Instantiate(preFabs[cORs], position, rotation);
                }
            }
        }
    }
}
