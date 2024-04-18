using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    private Animals_Controller deer;
    
    // Start is called before the first frame update
    void Start()
    {
        deer = GetComponent<Animals_Controller>();
    }

    public void sucess()
    {
        deer.v_cervo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
