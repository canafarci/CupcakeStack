using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using AmazingAssets.CurvedWorld.Example;

public class DisableFollow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CinemachineVirtualCamera cam = GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FirstCamera).GetComponent<CinemachineVirtualCamera>();
            cam.m_Follow = null;
            cam.m_LookAt = null;
        }
    }
}