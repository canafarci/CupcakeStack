using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class MoneyText : MonoBehaviour
{
    public int Value, CreationIndex;
    TextMeshProUGUI _text;
    bool _isInCoolDown = true;
    bool _gottenBigger = false;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        Destroy(gameObject, 1.5f);
        StartCoroutine(EndCooldown());
    }

    public void SetMoneyText(int value, int creationIndex, Vector3 targetPos)
    {
        Move(targetPos);
        Value = value;
        CreationIndex = creationIndex;
        _text.text = "$" + Value.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isInCoolDown && other.CompareTag("MoneyText"))
        {
            MoneyText otherMoneyText = other.GetComponentInChildren<MoneyText>();

            if (otherMoneyText.CreationIndex > CreationIndex) { return; }
            if (!_gottenBigger)
            {
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                _gottenBigger = true;
            }
            Destroy(other.gameObject);

            Value += otherMoneyText.Value;
            _text.text = "$" + Value.ToString();

            GetComponent<ITweener>().Tween();
        }
    }

    private void Move(Vector3 targetPos)
    {
        //Vector3 targetPos = new Vector3(transform.position.x / 10f + 2f, 4f, zPos);
        transform.DOMove(targetPos, .75f);
    }

    IEnumerator EndCooldown()
    {
        yield return new WaitForSeconds(.6f);
        _isInCoolDown = false;
    }
}