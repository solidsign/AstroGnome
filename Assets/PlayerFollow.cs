using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 offset;

    private void Update()
    {
        Vector3 pos = player.position + (Vector3)offset;
        pos.z = -10f;
        transform.position = pos;
    }
}
