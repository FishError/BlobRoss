using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void StartPaletteEffect()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
