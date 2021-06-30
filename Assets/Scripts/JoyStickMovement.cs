using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickMovement : MonoBehaviour
{
    private static JoyStickMovement instance;
    public static JoyStickMovement Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<JoyStickMovement>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<JoyStickMovement>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<JoyStickMovement>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameObject lever;
    public GameObject stickBg;
    Vector3 stickFirstPosition;
    public Vector3 joyVec;
    float stickRadius;

    bool onClick = false;

    private void Start()
    {
        stickRadius = stickBg.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    public void PointDown()
    {
        stickBg.transform.position = Input.mousePosition;
        lever.transform.position = Input.mousePosition;
        stickFirstPosition = Input.mousePosition;
        onClick = true;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 dragPosition = pointerEventData.position;
        joyVec = (dragPosition - stickFirstPosition).normalized;

        float stickDistance = Vector3.Distance(dragPosition, stickFirstPosition);

        if (stickDistance < stickRadius)
        {
            lever.transform.position = stickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            lever.transform.position = stickFirstPosition + joyVec * stickRadius;
        }
        onClick = true;
    }
    public void Drop()
    {
        joyVec = Vector3.zero;
        onClick = false;
        stickBg.transform.position = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2 - 600);
        lever.transform.position = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2 - 600);
    }

    public bool Click()
    {
        return onClick;
    }
}
