using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] LayerMask terrainLayer;
    Vector2 moveDirection;

    [SerializeField] Collider2D bottomCollider;
    [SerializeField] Collider2D frontCollider;

    void Start()
    {
        moveDirection = Vector2.right * moveSpeed;
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);

        //절벽, 벽 감지해서 방향전환
        if (!bottomCollider.IsTouchingLayers(terrainLayer) || frontCollider.IsTouchingLayers(terrainLayer))
        {
            moveDirection = -moveDirection;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
        }
    }
}
