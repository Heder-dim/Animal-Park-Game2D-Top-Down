using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSceneNPC : MonoBehaviour
{
    public DialogueControl controlScene;
    public string sceneSwap;
    public int swap;

    void Start()
    {
      
    }
    public void DefineSwap()
    {
        if (swap == 1)
        {
            controlScene.passScene = 1;
            controlScene.sceneName = sceneSwap;
        }
        else
        {
            controlScene.passScene = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
