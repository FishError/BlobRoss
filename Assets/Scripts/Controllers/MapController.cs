using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Map Settings")]
    public int maxWidth;
    public int maxHeight;
    public string roomType;

    // Start is called before the first frame update
    void Start()
    {
        PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, roomType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
