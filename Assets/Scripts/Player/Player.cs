using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public GameObject gameoverScreen;

    [SerializeField]
    private float jumpForce = 11f;

    public float kecepatan, scaleX;

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    [SerializeField] public AudioSource jumpSoundEffect;
    [SerializeField] public AudioSource backgroundSound;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        backgroundSound.Play();

    }

  
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    void jalan_kiri()
    {
        if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName("Idle"))
        {
            
            GetComponent<Animator> ().SetTrigger("jalan");
        }
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.x);
        transform.Translate(Vector3.left * kecepatan * Time.fixedDeltaTime, Space.Self);
    }

    void jalan_kanan()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
            GetComponent<Animator> ().SetTrigger("jalan");
        }
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.x);
        transform.Translate(Vector3.right * kecepatan * Time.fixedDeltaTime, Space.Self);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSoundEffect.Play();
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void berhenti()
    {
        GetComponent<Animator> ().SetTrigger("stop");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jalan_kiri();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            jalan_kanan();
        }
        
        if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            berhenti();
        }
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("We Landed on Ground");
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuScreen.SetActive(true);

    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }
}

   


