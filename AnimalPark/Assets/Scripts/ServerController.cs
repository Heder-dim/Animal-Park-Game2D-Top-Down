using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    public GameObject server, player, joy;

    private Player playerJ;
    private PlayerS playerS;
    void Start()
    {
        playerJ = player.GetComponent<Player>();
        playerS = player.GetComponent<PlayerS>();
        if (PlayerPrefs.GetInt("joystick") == 1)
        {
            server.SetActive(false);
            playerJ.enabled = true;
            playerS.enabled = false;
            joy.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("smartwatch") == 1)
        {
            server.SetActive(true);
            playerJ.enabled = false;
            playerS.enabled = true;
            joy.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
