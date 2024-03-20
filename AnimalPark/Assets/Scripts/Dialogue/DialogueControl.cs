using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueControl : MonoBehaviour
{

    public enum idiom
    { 
    
    }

    [Header("Components")]
    public GameObject dialogueObj; // janela do dialogo
    public Image profileSprite; // sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; // nome do npc

    [Header("Settings")]
    public float typingSpeed; // velocidade da fala

    //Vari�veis de controle
    private bool isShowing; // se a janela est� visivel
    private int index; // index das falas
    private string[] sentences;

    public static DialogueControl instance;

    //Awake � chamado antes de todos os Starts()
    private void Awake()
    {
        instance = this;   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence() 
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    //pular pra pr�xima fala
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            // enquanto ainda tem texto
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // quando terminar os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                Scene();
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

    public void Scene()
    {
        SceneManager.LoadScene("MiniGameCervo");
    }


}
