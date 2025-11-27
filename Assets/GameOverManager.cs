using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public string sceneToLoad;    // nome da cena do jogo normal

    private bool isGameOver = false;

    public void ShowGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // pausa o jogo
        gameOverUI.SetActive(true);
    }

    public void TryAgain()
    {
        Time.timeScale = 1f; // volta o tempo ao normal
        SceneManager.LoadScene(sceneToLoad);
    }
}
