using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove1 : MonoBehaviour
{
    #region Variables
    [SerializeField] float normalSpeed;
    float speed;
    [SerializeField] float speedUp;
    [SerializeField] float jumpForce;
    bool isGround;
    float direction;
    public static PlayerMove1 Instance;
    int jumps;
    #endregion


    #region References
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask jumpableGround;
    [SerializeField] GameObject trail;
    [SerializeField] GameObject healthBar;
    #endregion

    private enum playerState
    {
        Idle,
        Run,
        Jump,
        Fall
    }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGround = true;
        direction = 1f;
        speed = normalSpeed;
        jumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGround)
        {
            isGround = IsGrounded();
        }

        Move();
        AnimationActions();
        SpeedUp();


    }

    
    void Move()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            healthBar.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            direction = 1f;
        }
        else if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            healthBar.transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
            direction = -1f;
        }
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && doubleJump())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            AudioManager.Instance.PlaySFX("Jump");
            jumps++;
        }
        if(IsGrounded())
        {            
            jumps = 0;
        }
    }

    private void AnimationActions()
    {
        playerState playerAnim;

        if (rb.velocity.x < 0f)
        {
            //spriteRenderer.flipX = true;
            playerAnim = playerState.Run;
            
        }
        else if (rb.velocity.x > 0f)
        {
            //spriteRenderer.flipX = false;
            playerAnim = playerState.Run;
            
        }
        else playerAnim = playerState.Idle;

        if (rb.velocity.y > 0.1f) playerAnim = playerState.Jump;
        else if (rb.velocity.y < -0.1f) playerAnim = playerState.Fall;

        animator.SetInteger("State", (int)playerAnim);

    }
    bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, jumpableGround);
    }

    public float getDirection()
    {
        return direction;
    }
    void SpeedUp()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedUp;
            trail.SetActive(true);
        }
        else
        {
            speed = normalSpeed;
            trail.SetActive(false);
        }

    }
    bool doubleJump()
    {
        if (jumps < 1) return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End")) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
