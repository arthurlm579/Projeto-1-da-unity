using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo..."); // Mostra no console, útil para testar no Editor
        Application.Quit(); // Fecha o jogo no build
    }
}
