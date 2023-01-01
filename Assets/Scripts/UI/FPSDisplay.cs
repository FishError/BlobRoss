using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;
    private int frameRate;
    private float hudRefreshRate = 1f;
    private float timer;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update() {
        if(Time.unscaledTime > timer)
        {
            frameRate = (int)(1f / Time.unscaledDeltaTime);
            FpsText.text = frameRate.ToString() + " FPS";
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}
