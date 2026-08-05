using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;
    public TMP_Text bestTimeText; // Drag your Best Time TMP Text component here

    private float elapsedTime = 0f;
    private bool isRunning = true;

    void Awake()
    {
        // Resets the best time every time you press Play in Unity
        PlayerPrefs.DeleteKey("BestTime");
    }

    void Start()
    {
        DisplayBestTime();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = FormatTime(elapsedTime);
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
        if (timerText != null)
        {
            timerText.text = "00:00";
        }
    }

    // Call this when the player reaches the finish/end line
    public void CompleteLevel()
    {
        isRunning = false;

        // Get previous best time (defaults to max float if no score exists yet)
        float savedBest = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        // Check if current run is faster than previous best
        if (elapsedTime < savedBest)
        {
            PlayerPrefs.SetFloat("BestTime", elapsedTime);
            PlayerPrefs.Save();
        }

        DisplayBestTime();
    }

    private void DisplayBestTime()
    {
        if (bestTimeText != null)
        {
            float best = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
            if (best == float.MaxValue)
            {
                bestTimeText.text = "--:--";
            }
            else
            {
                bestTimeText.text = " " + FormatTime(best);
            }
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}