using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animals_Controller : MonoBehaviour
{
    public GameObject _cervo;
    public GameObject _onca;

    void Start()
    {
        if(PlayerPrefs.GetInt("Deer") == 1)
        {
            _cervo.SetActive(true);
        }

    }

    void Update()
    {
    }
}
