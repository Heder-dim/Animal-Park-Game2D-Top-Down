using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private int index;
    public List<Transform> paths = new List<Transform>();   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f) 
        { 
            if (index < paths.Count - 1) 
            {
                index++;
            }
            else 
            {
                index = 0;
            }
        
        }
    }
}
