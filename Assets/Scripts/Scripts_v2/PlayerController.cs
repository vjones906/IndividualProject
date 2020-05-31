using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public Animator playerAnim;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource audioSource;
    public bool onGround;
    public bool gameOver;

    public float jumpSpeed;
    private Vector3 hozDir;

    private EventManager eventManager;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        onGround = true;
        gameOver = false;
        hozDir = new Vector3(0, 0, 0);

        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.AddForce(Vector3.down);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                onGround = false;
                playerRigidBody.velocity = new Vector3(0, jumpSpeed, 0);
                playerAnim.SetTrigger("Jump_trig");
                audioSource.PlayOneShot(jumpSound, 0.75f);
            }
        }
    }

    public void Deactivate()
    {
        isActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //game over if the player hits an obstacle
        if (collision.gameObject.CompareTag("ObstacleUpper") || collision.gameObject.CompareTag("ObstacleLower"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            eventManager.gameOverEvent?.Invoke();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 2.0f);
        }

        //set on ground state to true if we hit the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //collect lantern pick ups and add to the score
        if (collision.gameObject.CompareTag("Lantern"))
        {
            eventManager.targetDestroyed?.Invoke(10);
            Destroy(collision.gameObject);
        }
    }
}
