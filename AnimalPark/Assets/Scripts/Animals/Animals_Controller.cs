using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animals_Controller : MonoBehaviour
{
    public bool v_cervo = false;
    public GameObject _cervo;
    public GameObject _onca;

    public bool V_cervo
    {
        get { return v_cervo; }
        set { v_cervo = value; }
    }
    void Start()
    {
        if(v_cervo == true)
        {
            _cervo.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
