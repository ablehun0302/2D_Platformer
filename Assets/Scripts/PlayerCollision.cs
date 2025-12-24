using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isProcessed = false;

    void OnEnable()
    {
        isProcessed = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 위험요소에 닿을 시 사망
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard") && !isProcessed)
        {
            isProcessed = true;
            GameManager.instance.PlayerDead();
        }
    }
}
