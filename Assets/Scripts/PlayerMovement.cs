using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator playerAnim;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public float walkSpeed = 2f;
    public float jumpSpeed = 8f;
    public float gravityForce = 30f;
    private Vector3 hozDir = Vector3.zero;
    public bool gameOver = false;
    public bool onGround = true;
    public GameObject lantern;
    public ParticleSystem smokeParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if (onGround)
        {
            hozDir = new Vector3(0, 0, -Input.GetAxis("Horizontal"));
            hozDir = transform.TransformDirection(hozDir);
            hozDir *= jumpSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                hozDir.y = jumpSpeed;
                audioSource.PlayOneShot(jumpSound, 1.0f);
            }
        }
        hozDir.y -= gravityForce * Time.deltaTime;
        controller.Move(hozDir * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //game over if the player hits an obstacle
        if (collision.gameObject.CompareTag("Raindrop"))
        {
            gameOver = true;
            onGround = false;
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lantern"))
        {
            Destroy(other.gameObject);
            smokeParticle.Play();
        }
    }
}