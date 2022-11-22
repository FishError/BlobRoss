using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealthController : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public TextMeshProUGUI text;
    public Player player;
    public string deathScene;
    [SerializeField] private Gradient gradient;

    private void Start()
    {
        player = player.GetComponent<Player>();
        player.ResetMaxHealthPoints();
        player.ResetHealthPoints();
        fill.color = gradient.Evaluate(1f);
        text.text = player.HealthPoints + "/" + player.MaxHealthPoints;
        slider.maxValue = player.MaxHealthPoints;
    }

    private void Update()
    {
        slider.value = player.HealthPoints;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        text.text = player.HealthPoints + "/" + player.MaxHealthPoints;
        if (player.HealthPoints <= 0)
        {
            player.StateMachine.ChangeState(player.DeathState);
            player.ResetMaxHealthPoints();
            player.ResetHealthPoints();
            SceneManager.LoadScene(deathScene);
            //TODO: check if death animation has ended
        }
    }
}