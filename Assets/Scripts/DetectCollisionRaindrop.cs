using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionRaindrop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destroys the raindrops if they hit a platform before being able to hit the "out of bounds" marker
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}