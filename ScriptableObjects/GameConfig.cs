using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/New Game Config", order = 0)]
public class GameConfig : ScriptableObject
{
    public float PlayerSpeed, EndGameHeight, EndGameDuration;
    public GameObject MoneyText, MoneyVFX;

    [Header("AUDIO")]
    public AudioConfig DragStartConfig;
}

[System.Serializable]
public class AudioConfig
{
    public AudioClip Audio;
    public float Volume;
}
