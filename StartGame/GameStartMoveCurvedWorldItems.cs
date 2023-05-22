using AmazingAssets.CurvedWorld.Example;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartMoveCurvedWorldItems : MonoBehaviour
{
    ChunkSpawner _chunkSpawner;
    private void Awake() => _chunkSpawner = FindObjectOfType<ChunkSpawner>();
    private void OnEnable() => GameStart.OnGameStart += OnGameStart;
    private void OnDisable() => GameStart.OnGameStart -= OnGameStart;

    private void OnGameStart()
    {
        _chunkSpawner.movingSpeed = GameManager.Instance.References.GameConfig.PlayerSpeed;

        foreach (ItemSpawner itemSpawner in FindObjectsOfType<ItemSpawner>(true))
        {
            itemSpawner.enabled = true;
        }
    }
}
