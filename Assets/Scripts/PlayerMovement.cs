using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator playerAnim;
    public ParticleSystem dirtSplat;
    public AudioClip jumpSound;
    private AudioSource audioSource;
    public float walkSpeed = 10f;
    public float jumpSpeed = 8f;
    public float gravityForce = 30f;
    private Vector3 hozDir = Vector3.zero;
    public bool gameOver = false;
    public bool onGround = true;

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
            hozDir = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            hozDir = transform.TransformDirection(hozDir);
            hozDir *= jumpSpeed;
            dirtSplat.Play();

            if (Input.GetButtonDown("Jump"))
            {
                hozDir.y = jumpSpeed;
                dirtSplat.Stop();
                playerAnim.SetTrigger("Jump_trig");
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
            dirtSplat.Stop();
            gameOver = true;
            onGround = false;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
