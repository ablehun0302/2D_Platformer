using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Vector2 moveDirection;

    [SerializeField] Collider2D bottomCollider;
    [SerializeField] Collider2D frontCollider;
    [SerializeField] CompositeCollider2D terrainCollider;

    void Start()
    {
        moveDirection = Vector2.right * moveSpeed;
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);

        //절벽, 벽 감지해서 방향전환
        if (!bottomCollider.IsTouchingLayers(LayerMask.GetMask("Terrain")) || frontCollider.IsTouchingLayers(LayerMask.GetMask("Terrain")))
        {
            moveDirection = -moveDirection;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
        }
    }
}
