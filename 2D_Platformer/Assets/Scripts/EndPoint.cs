using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 도착지점에 닿을 시 클리어
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.instance.FinishGame(false);
        }
    }
}
