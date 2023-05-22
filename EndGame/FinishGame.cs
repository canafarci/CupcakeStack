using System.Collections;
using System.Collections.Generic;
using AmazingAssets.CurvedWorld.Example;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] int _sceneIndexToLoad;
    private ChunkSpawner _chunkController;
    private void Awake() => _chunkController = FindObjectOfType<ChunkSpawner>();
    public void EndLevel()
    {
        _chunkController.movingSpeed = 0f;

        StartCoroutine(GameManager.Instance.SceneLoader.DelayedLoadScene(_sceneIndexToLoad, 3f));
    }
}
