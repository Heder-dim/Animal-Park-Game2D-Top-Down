using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verification : MonoBehaviour
{
    public bool _cervo = false;

    public bool funcCervo
    {
        get { return _cervo;}
        set { _cervo = value; } 
    }
}
