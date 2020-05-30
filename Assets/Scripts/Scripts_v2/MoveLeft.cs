using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerController;
    private float leftBoundaryBG = -1300;
    private float leftBoundaryEL = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBoundaryEL && gameObject.CompareTag("ObstacleUpper"))
        {
            Destroy(gameObject);
        }

        if (transform.position.x < leftBoundaryEL && gameObject.CompareTag("ObstacleLower"))
        {
            Destroy(gameObject);
        }

        if (transform.position.x < leftBoundaryEL && gameObject.CompareTag("Lantern"))
        {
            Destroy(gameObject);
        }

        if (transform.position.x < leftBoundaryBG && gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
