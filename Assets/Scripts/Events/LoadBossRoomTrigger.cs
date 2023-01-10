using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBossRoomTrigger : MonoBehaviour
{
    public MapController mapController;

    private void Start()
    {
        GameObject mc = GameObject.Find("MapController");
        if (mc != null)
            mapController = mc.GetComponent<MapController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mapController != null)
        {
            mapController.UnloadMapAndLoadBossRoom();
        }
    }
}
