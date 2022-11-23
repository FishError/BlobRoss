using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomController : MonoBehaviour
{
    public GameObject grid;
    public Transform enterPoint;
    public GameObject boss;

    public void SetCameraConfiner(GameObject cinemachineCamera)
    {
        cinemachineCamera.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = grid.GetComponent<Collider2D>();
    }

    public void SetPlayerAtEnterPoint(GameObject player)
    {
        player.transform.position = enterPoint.position;
        boss.GetComponent<Boss>().target = player;
    }
}
