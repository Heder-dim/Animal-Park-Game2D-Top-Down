using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyCount = 0; // Inicializando explicitamente o valor de keyCount

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            setKey(keyCount + 1);
            Debug.Log(getKeyCount());
        }
    }
    public void setKey(int Key)
    {
        this.keyCount = Key;
    }

    public int getKeyCount()
    {
        Debug.Log("enviando key");
        return keyCount;
    }
}
