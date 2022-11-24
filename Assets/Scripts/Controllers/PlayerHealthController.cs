using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class PlayerHealthController : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public TextMeshProUGUI text;
    public Player player;
    [SerializeField] private Gradient gradient;

    private void Start()
    {
        player = player.GetComponent<Player>();
        player.ResetMaxHealthPoints();
        player.ResetHealthPoints();
        fill.color = gradient.Evaluate(1f);
        text.text = Mathf.Floor(player.HealthPoints) + "/" + player.MaxHealthPoints;
        slider.maxValue = player.MaxHealthPoints;
    }

    private void Update()
    {
        slider.value = player.HealthPoints;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        text.text = Mathf.Floor(player.HealthPoints) + "/" + player.MaxHealthPoints;
    }
}