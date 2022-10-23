using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public void SetCameraFollow(Transform t)
    {
        virtualCamera.Follow = t;
    }
}
