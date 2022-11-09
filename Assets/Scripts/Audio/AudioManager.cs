using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject musicController;

    private void Awake()
    {
        musicController = GameObject.Find("AudioController");
        
        if(musicController == null)
        {
            musicController = this.gameObject;
            musicController.name = "AudioController";
            DontDestroyOnLoad(musicController);
        }
        else
        {
            if(this.gameObject.name != "AudioController")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
