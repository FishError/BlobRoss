using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private AudioSource audioSource;

    public void StartPaletteEffect()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
