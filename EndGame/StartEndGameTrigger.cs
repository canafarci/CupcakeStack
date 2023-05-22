using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.GetComponent<Collider>().isTrigger)
        {
            //CinemachineVirtualCamera cam = GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FirstCamera).GetComponent<CinemachineVirtualCamera>();

            //cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadTime = 0.2f;
            //cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadSmoothing = 2f;

            FindObjectOfType<StartEndGame>().EndGameStart();
            FindObjectOfType<StackMover>().PauseStacker();
            //GetComponent<Collider>().enabled = false;
        }
    }
}

