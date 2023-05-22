using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Vector3 _speed;
    private void Update()
    {
        Vector3 pos = transform.position;
        pos += Time.deltaTime * _speed;
        transform.position = pos;
    }
}
