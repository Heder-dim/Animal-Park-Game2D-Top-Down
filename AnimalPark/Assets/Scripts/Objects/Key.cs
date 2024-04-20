// Key.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    private int keyCount = 0;
    public int num_keys = 0;
    public GameObject criature;
    public int minigameNum;


    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            keyCount++; 
            Debug.Log("Quantidade de chaves: " + keyCount);
        }
        if (collision.gameObject.CompareTag("Object") && keyCount == num_keys)
        {
            Debug.Log("O jogador possui chaves o suficiente.");
            Destroy(collision.gameObject);
            criature.SetActive(true);
            switch (minigameNum)
            {
                case 0:
                    PlayerPrefs.SetInt("Deer", 1);
                    break;
                case 1:
                    PlayerPrefs.SetInt("ounce", 1);
                    break;
            }
        }
    }
    // Define a quantidade de chaves
    public void SetKey(int key)
    {
        keyCount = key;
    }

    // Retorna a quantidade de chaves
    public int GetKeyCount()
    {
        return keyCount;
    }

}
