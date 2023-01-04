using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXDestroyer : MonoBehaviour
{
    AudioSource audioOrigin;
    public GameObject parentObject;
    public bool playAfterDestroy = false;
    
    private void Start()
    {
        audioOrigin = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(parentObject == null && !playAfterDestroy)
        {
            Destroy(gameObject);
        }
        
        if (!audioOrigin.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
