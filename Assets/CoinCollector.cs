using UnityEngine;
using TMPro; // Necessário para o texto de contagem
using UnityEngine.SceneManagement; // Opcional: Se quisesse carregar outra cena
// Usamos TMPro no lugar de UnityEngine.UI, que é a opção mais moderna.

public class CoinCollector : MonoBehaviour
{
    // Variável Pública para o limite de moedas, fácil de mudar no Inspector
    public int winConditionCount = 10;

    // Referências de UI
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI victoryText; // <-- NOVO: Texto da mensagem de vitória

    private int coinCount = 0;

    // --- Funções Nativas da Unity ---

    private void Start()
    {
        UpdateCoinText();
        // Garante que o texto de vitória esteja invisível no início do jogo
        if (victoryText != null)
        {
            victoryText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // Verifica se a moeda já foi coletada (apenas uma precaução extra)
            if (coinCount < winConditionCount)
            {
                // Ação de Coleta
                coinCount++;
                Destroy(other.gameObject);
                UpdateCoinText();

                // 3. Verificação da Condição de Vitória (NOVO)
                if (coinCount >= winConditionCount)
                {
                    WinGame();
                }
            }
        }
    }

    // --- Funções Personalizadas ---

    // 1. Função de Atualização do Texto (A mesma de antes)
    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Moedas: " + coinCount.ToString() + " / " + winConditionCount.ToString();
        }
    }

    // 2. Função de Vitória (NOVO)
    private void WinGame()
    {
        // 1. Exibir a mensagem de vitória
        if (victoryText != null)
        {
            victoryText.text = "VOCÊ VENCEU!";
            victoryText.gameObject.SetActive(true);
        }

        // 2. Congelar o jogo
        // Definir a escala de tempo para 0 pausa o jogo (física, animações, movimento)
        Time.timeScale = 0f;

        // Opcional: Você pode querer desligar o input do personagem aqui também
        // Ex: GetComponent<PlayerMovement>().enabled = false;
    }
}