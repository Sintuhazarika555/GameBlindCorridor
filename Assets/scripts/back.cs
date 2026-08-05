using UnityEngine;
using UnityEngine.SceneManagement;

public class back: MonoBehaviour
{
    // Exact name of your Hero / Start Menu scene in Build Settings
    [SerializeField] private string startSceneName = "StartScene";

    void Update()
    {
        // Allows PC players to press ESC (or Android back button) to return
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToStartScene();
        }
    }

    public void GoToStartScene()
    {
        // Unpause time in case the game was stopped/paused
        Time.timeScale = 1f;

        // Load the Hero Scene
        SceneManager.LoadScene(startSceneName);
    }
}