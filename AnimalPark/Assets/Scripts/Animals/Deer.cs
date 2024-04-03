using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    private Verification deer;
    
    // Start is called before the first frame update
    void Start()
    {
        deer = GetComponent<Verification>();
    }

    public void sucess()
    {
        deer._cervo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
