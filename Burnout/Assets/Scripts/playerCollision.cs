using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public GameManager gm;
    public playerMovement movement;
    public LightChanger light;


    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "enemy")
        {
            movement.enabled = false;
            gm.EndGame();
        }

        if (collisionInfo.collider.tag == "Refill")
        {
            Destroy(collisionInfo.gameObject);
            light.LightReset();

            
        }
    }


}
