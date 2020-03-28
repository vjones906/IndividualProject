using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float jumpSpeed = 8f;
    public float gravityForce = 30f;
    private Vector3 hozDir = Vector3.zero;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            hozDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            hozDir = transform.TransformDirection (hozDir);
            hozDir *= jumpSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                hozDir.y = jumpSpeed;
            }
        }
        hozDir.y -= gravityForce * Time.deltaTime;
        controller.Move(hozDir * Time.deltaTime);
    }
}
