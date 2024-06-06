using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed; // Define a default speed

    private Vector3 playerDirection;

    public Vector3 direction
    {
        get { return playerDirection; }
        set { playerDirection = value; }
    }

    void Update()
    {
        // Update the player position based on the direction and speed
        transform.position += playerDirection * playerSpeed * Time.deltaTime;
    }
}
