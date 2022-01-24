using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    float horizontalInput;
    float verticalInput;
    Rigidbody playerRB;
    Animator playerAnim;
    public float gravityModifier;
    public float jumpForce;
    public static bool downPressed = false;

    public GameObject positionRef;
    public float maxRange;
    public float minRange;

    public SpawnManager refSM;
    public bool gameOver;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioSource playerAudio;
    bool isGround;



    // Start is called before the first frame update
    void Start()
    {

        playerAnim = gameObject.GetComponent<Animator>();
        playerRB = gameObject.GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameOver = false;
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Movement();
            CheckForwardMovement();
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
                Jump();
        }

    }

    void CheckForwardMovement()
    {
        if (verticalInput != 0)
            playerAnim.SetFloat("Speed_f", 0.3f);
    }
    void Jump()
    {
        isGround = false;
        playerRB.AddForce((Vector3.forward * 30) + (Vector3.up * jumpForce), ForceMode.Impulse);
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        playerAnim.SetTrigger("Jump_trig");
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        playerRB.AddForce(Vector3.forward * Time.deltaTime * speed * verticalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("road"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("game over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(hitSound, 1.0f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("spawnTrigger"))
            refSM.SpawnGroundPatch();
    }
}
