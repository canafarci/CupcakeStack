using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public GameConfig GameConfig;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(PrefKeys.GameplayLoop))
            PlayerPrefs.SetInt(PrefKeys.GameplayLoop, 1);
    }
}
