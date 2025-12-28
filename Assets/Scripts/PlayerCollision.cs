using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isProcessed = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    void OnEnable()
    {
        isProcessed = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isProcessed) return;

        // 위험요소에 닿을 시 사망
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            isProcessed = true;
            gameManager.PlayerDead();
        }

        // 도착지점에 닿을 시 클리어
        if (collision.gameObject.layer == LayerMask.NameToLayer("EndPoint"))
        {
            isProcessed = true;
            gameManager.GameClear();
        }
    }
}
