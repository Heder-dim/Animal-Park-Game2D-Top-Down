using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerspeed;
    private Vector3 playerDirection;

    public Vector3 direction
    {
        get { return playerDirection; }
        set { playerDirection = value; }
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0f;

            playerDirection = (touchPosition - transform.position).normalized;

            transform.position = transform.position + playerDirection * playerspeed * Time.deltaTime;
        }
        else{

            playerDirection.Set(0,0,0);
        }
    }
}
