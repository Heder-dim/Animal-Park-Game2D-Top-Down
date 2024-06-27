using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float velocidadeCenario;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementarCenario();
    }

    public void movementarCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velocidadeCenario, 0);
        GetComponent<Renderer>(). material.mainTextureOffset = deslocamento;
    }
}
