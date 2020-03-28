using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionRaindrop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    //game over if the player hits an obstacle
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}