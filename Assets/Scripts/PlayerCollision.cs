using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);

        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
    }
}
