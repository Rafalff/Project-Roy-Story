using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    public float scaleX;
    [SerializeField] private float jumpForce = 11f;
    [SerializeField] public AudioSource jumpSoundEffect;
    [SerializeField] public AudioSource backgroundSound;

    public GameObject pauseMenuScreen;
    public GameObject gameoverScreen;

    private SpriteRenderer sr;

    void Start()
    {
        scaleX = transform.localScale.x;
    }

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        backgroundSound.Play();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.x);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.x);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        anim.SetTrigger("jump");
        jumpSoundEffect.Play();
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
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
