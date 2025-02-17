using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused;

    public void GameOverLose(bool didLose)
    {
        if (didLose)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GameOverWin(bool didWin)
    {
        if (didWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
