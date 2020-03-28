using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionPlayer : MonoBehaviour
{
    public bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Game over if the player hits a raindrop
        if (collision.gameObject.CompareTag("Raindrop"))
        {
            Destroy(gameObject);
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}