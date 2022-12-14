using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomController : MonoBehaviour
{
    public GameObject grid;
    public Transform enterPoint;
    public GameObject boss;

    private void Update()
    {
        if(boss == null)
        {
            StartCoroutine(GameObject.Find("GameController").GetComponent<GameController>().WaitWinScreen());
        }

        EnableHpBar();
    }

    public void SetCameraConfiner(GameObject cinemachineCamera)
    {
        cinemachineCamera.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = grid.GetComponent<Collider2D>();
    }

    public void SetPlayerAtEnterPoint(GameObject player)
    {
        player.transform.position = enterPoint.position;
        boss.GetComponent<Boss>().target = player;
    }

    public void EnableHpBar()
    {
        if (boss != null && boss.GetComponent<Renderer>().isVisible)
        {
            GameObject hpBar = boss.transform.Find("BossStatusBar").gameObject;
            hpBar.SetActive(true);
        }
    }
}
