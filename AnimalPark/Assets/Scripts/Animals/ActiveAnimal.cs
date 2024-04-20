using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimal : MonoBehaviour
{
    private int _minigameNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void activeAnimal(int minigameNum)
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
