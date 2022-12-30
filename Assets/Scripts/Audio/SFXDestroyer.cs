using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXDestroyer : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject parentObject;
    public bool playAfterDestroy = false;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(parentObject == null && !playAfterDestroy)
        {
            Destroy(gameObject);
        }
        
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
