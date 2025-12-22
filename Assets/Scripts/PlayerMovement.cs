using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed = 10;
    [SerializeField] float moveForce = 7;
    [SerializeField] float jumpForce = 21;

    float moveInput;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        rb.AddForce(Vector2.right * moveForce * moveInput);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed), rb.velocity.y);
    }
    
    /// <summary>
    /// 점프 입력 및 제어
    /// </summary>
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

}
