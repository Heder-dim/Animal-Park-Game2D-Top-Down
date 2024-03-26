using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veriction_Key : MonoBehaviour
{
    private int player_key;
    private int player_keys;
    private Key key; // Certifique-se de que esteja inicializado corretamente
    public int num_key_verification;
    public GameObject criature;

    // Método para configurar o valor de player_key com base no número de chaves do jogador
    private int setPlayer_key()
    {
        
         return player_key = key.getKeyCount();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player_keys += setPlayer_key();
        Debug.Log(player_key);
        if (collision.gameObject.CompareTag("Object") && player_key == num_key_verification)
        {
            Debug.Log("ojkdfmdjfsd");
            Destroy(collision.gameObject);
            criature.SetActive(true);
        }
    }
}
