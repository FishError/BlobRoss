using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossStatusBarController : MonoBehaviour
{
    public Color32 borderColor, fillColor;
    public Image icon, iconBorder, fill;
    public Sprite bossIcon;
    public Slider slider;
    public TextMeshProUGUI hpText, bossNameText;
    public string bossName;
    public Boss boss;

    private void Start()
    {
        iconBorder.color = new UnityEngine.Color(borderColor.r / 255f, borderColor.g / 255f, borderColor.b / 255f);
        fill.color = new UnityEngine.Color(fillColor.r / 255f, fillColor.g / 255f, fillColor.b / 255f);
        bossNameText.text = bossName;
        icon.sprite = bossIcon;
        boss = boss.GetComponent<Boss>();
        boss.ResetMaxHealthPoints();
        boss.ResetHealthPoints();
        hpText.text = Mathf.Floor(boss.HealthPoints) + "/" + boss.MaxHealthPoints;
        slider.maxValue = boss.MaxHealthPoints;
    }

    private void Update()
    {
        slider.value = boss.HealthPoints;
        hpText.text = Mathf.Floor(boss.HealthPoints) + "/" + boss.MaxHealthPoints;

        if(boss.HealthPoints <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }


}