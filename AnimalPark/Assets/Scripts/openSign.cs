using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class openSign : MonoBehaviour
{
    public GameObject painelInformacoes; // Painel de UI para mostrar as informa��es
    public string informacoesDoAnimal;   // Texto com as informa��es do animal
    public Button botaoInteragir;        // Refer�ncia ao bot�o de intera��o
    private bool playerProximo = false;  // Indica se o player est� pr�ximo da placa
    private TextMeshProUGUI textoInformacoes; // Refer�ncia ao TextMeshProUGUI

    void Start()
    {
        botaoInteragir.onClick.AddListener(InteragirComPlaca);
        textoInformacoes = painelInformacoes.GetComponentInChildren<TextMeshProUGUI>();
        painelInformacoes.SetActive(false); // Certifique-se de que o painel come�a desativado
        textoInformacoes.lineSpacing = 23.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerProximo = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerProximo = false;
            FecharPlaca();
        }
    }

    void InteragirComPlaca()
    {
        if (playerProximo)
        {
            if (!painelInformacoes.activeSelf)
            {
                AbrirPlaca();
            }
            else
            {
                FecharPlaca();
            }
        }
    }

    void AbrirPlaca()
    {
        painelInformacoes.SetActive(true);
        textoInformacoes.text = informacoesDoAnimal.Replace("\\n", "\n");
    }

    void FecharPlaca()
    {
        painelInformacoes.SetActive(false);
    }
}
