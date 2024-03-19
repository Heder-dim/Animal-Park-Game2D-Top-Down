using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public string interactButtonName = "Botao_Interacao";
    public LayerMask playerLayer;
    private bool dialogueOpened;

    public DialogueSettings dialogue;
    bool playerHit;

    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        
    }

    public void StartDialogue()
    {
        if (playerHit && !dialogueOpened) 
        {
            DialogueControl.instance.Speech(sentences.ToArray());
            dialogueOpened = true; 
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            dialogueOpened = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
