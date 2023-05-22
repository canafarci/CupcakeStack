using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandObstacle : Obstacle
{
    protected override void OnPlayerEnterObstacle(Collider other, StackableItem item)
    {
        GetComponent<Collider>().enabled = false;
        RemoveItem(other);
        SpawnVFX(other.transform);
    }

    private void SpawnVFX(Transform otherTransform)
    {
        GameObject prefab = GameManager.Instance.References.GameConfig.MoneyVFX;
        GameObject vfx = Instantiate(prefab,
                                    otherTransform.position + new Vector3(0f, 4f, 0f),
                                    prefab.transform.rotation);
        Destroy(vfx, .5f);
    }

    private void RemoveItem(Collider item)
    {
        item.transform.parent = transform;
        item.transform.DOLocalMove(Vector3.zero, .2f);
        StartCoroutine(HandAnimation());
    }

    IEnumerator HandAnimation()
    {
        Animator animator = GetComponentInParent<Animator>();
        animator.Play("GrabAnim");


        float delay = AnimationManager.GetAnimationLength("endgame_hand_endgame", animator);
        yield return new WaitForSeconds(delay / 4f);

        float zPos = (animator.transform.position.z < 0f) ? -10f : 10f;
        animator.transform.DOMoveZ(zPos, 1f);
    }
}
