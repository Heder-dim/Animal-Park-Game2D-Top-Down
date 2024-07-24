using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class openSign : MonoBehaviour
{
    public GameObject painelInformacoes; // Painel de UI para mostrar as informações
    public string informacoesDoAnimal;   // Texto com as informações do animal
    public Button botaoInteragir;        // Referência ao botão de interação
    private bool playerProximo = false;  // Indica se o player está próximo da placa
    private TextMeshProUGUI textoInformacoes; // Referência ao TextMeshProUGUI

    void Start()
    {
        botaoInteragir.onClick.AddListener(InteragirComPlaca);
        textoInformacoes = painelInformacoes.GetComponentInChildren<TextMeshProUGUI>();
        painelInformacoes.SetActive(false); // Certifique-se de que o painel começa desativado
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
