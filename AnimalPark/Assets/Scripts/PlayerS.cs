using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public float playerSpeed = 2.0f; // Ajuste este valor para desacelerar o personagem

    private Vector3 playerDirection;

    public Vector3 direction
    {
        get { return playerDirection; }
        set { playerDirection = value; }
    }

    void Update()
    {
        transform.position += playerDirection * playerSpeed * Time.deltaTime;
    }
}
