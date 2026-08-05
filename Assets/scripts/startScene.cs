using UnityEngine;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject _noticeBoardPanel;

    [Header("Settings")]
    [SerializeField] private string _gameSceneName = "SampleScene";

    public void OpenNoticeBoard()
    {
        if (_noticeBoardPanel != null)
        {
            _noticeBoardPanel.SetActive(true);
        }
        else
        {
            // Fallback if panel isn't assigned
            LoadGameplayScene();
        }
    }

    public void LoadGameplayScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_gameSceneName);
    }
}
