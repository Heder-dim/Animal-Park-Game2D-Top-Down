using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public float playerSpeed = 2.0f;

    private Vector3 playerDirection;

    void Update()
    {
        transform.position += playerDirection * playerSpeed * Time.deltaTime;
    }

    public void SetDirection(string direction)
    {
        switch (direction)
        {
            case "UP":
                playerDirection = Vector3.up;
                break;
            case "DOWN":
                playerDirection = Vector3.down;
                break;
            case "LEFT":
                playerDirection = Vector3.left;
                break;
            case "RIGHT":
                playerDirection = Vector3.right;
                break;
            default:
                playerDirection = Vector3.zero;
                break;
        }
    }
}
