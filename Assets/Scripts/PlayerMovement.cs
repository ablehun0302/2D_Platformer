using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed = 10;
    [SerializeField] float moveForce = 50;
    [SerializeField] float jumpForce = 21;

    float moveInput;
    bool isGrounded;
    bool isRunning;

    Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] Collider2D feetCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateAnimator();
        Move();
        Jump();
    }

    /// <summary>
    /// 좌우 움직임 입력 및 제어
    /// </summary>
    void Move()
    {
        // 좌우 입력
        moveInput = Input.GetAxisRaw("Horizontal");

        // 좌우 움직임 및 속도 제한
        rb.AddForce(Vector2.right * Time.deltaTime * moveForce * moveInput);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed), rb.velocity.y);

        // 방향 설정
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(moveInput, 1, 1);
        }
    }
    
    /// <summary>
    /// 점프 입력 및 제어
    /// </summary>
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            SoundManager.instance.jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// 애니메이션 상태를 변경
    /// </summary>
    void UpdateAnimator()
    {
        // 뛰고있는지 판별
        isRunning = Mathf.Abs(rb.velocity.x) > 0.5f;
        animator.SetBool("isRunning", isRunning);

        // 땅에 닿았는지 판별
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Terrain"));
        animator.SetBool("isGrounded", isGrounded);

        animator.SetFloat("velocityY", rb.velocity.y);
    }
}