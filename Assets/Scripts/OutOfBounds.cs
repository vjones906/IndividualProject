using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private float bottomLimit = 35.5f;

    // Update is called once per frame
    void Update()
    {
        // Destroy raindrops if y position is less than bottomLimit
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
