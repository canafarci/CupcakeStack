using System.Collections;
using System.Collections.Generic;
using AmazingAssets.CurvedWorld.Example;
using DG.Tweening;
using UnityEngine;

public class FinalStageTrigger : MonoBehaviour
{
    public int MaxStackCount;
    private ChunkSpawner _chunkController;
    [SerializeField] Transform _dollars, _handTarget;
    private void Awake() => _chunkController = FindObjectOfType<ChunkSpawner>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
            StartCoroutine(FinalStageRoutine(other.transform.parent));
    }
    public IEnumerator FinalStageRoutine(Transform player)
    {
        player.parent = _dollars;
        player.DOLocalMove(_handTarget.localPosition, .4f);
        player.DOLocalRotateQuaternion(_handTarget.rotation, .4f);

        _chunkController.movingSpeed = 0f;

        yield return new WaitForSeconds(.5f);
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.SecondCamera);

        _dollars.DOMoveY(GameManager.Instance.References.GameConfig.EndGameHeight,
                         GameManager.Instance.References.GameConfig.EndGameDuration);

        yield return new WaitForSeconds(GameManager.Instance.References.GameConfig.EndGameDuration + 2f);

        GetComponent<FinishGame>().EndLevel();


    }
}
