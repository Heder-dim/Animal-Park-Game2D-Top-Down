using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue_MiniGame : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;
    bool playerHit;

    public Button dialogueButton;

    private List<string> sentences = new List<string>();

    public GameObject box;


    private void Start()
    {
        GetNPCInfo();

        dialogueButton.onClick.AddListener(OpenDialogue);
    }

    void Update()
    {

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

    private void OpenDialogue()
    {
        if (playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }


    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if (hit != null)
        {
            playerHit = true;
            box.SetActive(true);
        }
        else
        {
            playerHit = false;
            box.SetActive(false);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}

