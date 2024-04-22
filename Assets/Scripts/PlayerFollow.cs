using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + cameraOffset;
    }
}
