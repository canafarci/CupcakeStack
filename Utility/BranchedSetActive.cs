using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BranchedSetActive : MonoBehaviour
{
    public CakeStage CakeStage;
    public ChoiceIndex ChoiceIndex;
    public void SetItemActive()
    {
        gameObject.SetActive(true);
        Vector3 scale = transform.localScale;
        transform.localScale = scale / 10f;
        transform.DOScale(scale, 0.3f);
    }
}
