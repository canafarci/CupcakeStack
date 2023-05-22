using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetActiveTrigger : MonoBehaviour
{
    protected CakeStage _cakeStage;
    [SerializeField] protected int _value = 1;
    int _creationIndexCounter = 0;
    [SerializeField] ParticleSystem _particle;

    [SerializeField] ChoiceIndex _choiceIndex;
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StackableItem stackableItem = other.GetComponent<StackableItem>();
            if (stackableItem == null || stackableItem.IsInStack)
                TriggerBehaviour(other);
        }
    }

    protected virtual void TriggerBehaviour(Collider other)
    {
        foreach (BranchedSetActive bsa in other.transform.GetComponentsInChildren<BranchedSetActive>(true))
        {
            if (bsa.CakeStage == _cakeStage && bsa.ChoiceIndex == _choiceIndex)
            {
                bsa.SetItemActive();
                PlayFX(other);
                break;
            }
        }
    }

    private void PlayFX(Collider other)
    {
        SpawnMoneyText(other);

        if (_particle != null)
            _particle.Play();
    }

    private void SpawnMoneyText(Collider other)
    {
        float spawnZPos = (other.transform.position.z < 0f) ? 6f : -6f;
        Vector3 pos = transform.position;
        pos.y = 0f;
        pos.z = spawnZPos;

        GameObject prefab = GameManager.Instance.References.GameConfig.MoneyText;
        GameObject moneyTextObject = GameObject.Instantiate(prefab, pos, Quaternion.identity);

        MoneyText moneytext = moneyTextObject.GetComponent<MoneyText>();

        float zPos = (other.transform.position.z < 0f) ? .5f : -.5f;

        Vector3 spawnpos = new Vector3(other.transform.position.x / 10f + 2f, 6f, other.transform.position.z + zPos);

        moneytext.SetMoneyText(_value, _creationIndexCounter, spawnpos);
        GameManager.Instance.ResourceManager.OnMoneyChange(_value);
        _creationIndexCounter++;
    }
}