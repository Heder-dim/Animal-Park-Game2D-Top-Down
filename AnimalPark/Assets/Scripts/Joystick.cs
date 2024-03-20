using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private float joystickRadius;

    void Start()
    {
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystick.transform.position = eventData.position;
        joystickBG.transform.position = eventData.position;
        joystickTouchPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragPos = eventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickBG.transform.position;
    }
}
