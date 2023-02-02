using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public GameManager gm;
    public playerMovement movement;

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "enemy")
        {
            movement.enabled = false;
            gm.EndGame();
        }
    }
}
