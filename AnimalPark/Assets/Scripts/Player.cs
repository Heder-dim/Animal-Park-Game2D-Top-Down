using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerspeed;

    private Vector3 playerDirection;
    private Joystick joystick;
    public Vector3 direction
    {
        get { return playerDirection; }
        set { playerDirection = value; }
    }
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        playerDirection = new Vector3(joystick.joystickVec.x, joystick.joystickVec.y, 0f);

        transform.position += playerDirection * playerspeed * Time.deltaTime;
    }
}
