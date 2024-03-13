using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Player player;
    private Animator animator;

    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            animator.SetInteger("Transition", 1);
        }
        else
        {
            animator.SetInteger("Transition", 0);
        }

        // Ajuste para garantir que a animação de movimento seja reproduzida apenas quando o jogador estiver se movendo
        if (player.direction.x != 0 || player.direction.y != 0)
        {
            if (player.direction.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (player.direction.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}
