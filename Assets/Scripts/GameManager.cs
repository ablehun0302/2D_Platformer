using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    [SerializeField] int timeLimit = 20;
    [SerializeField] int life = 3;

    Vector2 startPosition;
    int tenthsTicks = 9;
    bool isGameOver = false;

    [SerializeField] GameObject player;
    [SerializeField] GameObject followCamera;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startPosition = player.transform.position;
        StartCoroutine(TimeLimitCounter());
    }

    /// <summary>
    /// 플레이어 사망 시 실행
    /// </summary>
    public void PlayerDead()
    {
        // 목숨 감소, 플레이어와 카메라 비활성화
        life -= 1;
        player.SetActive(false);
        followCamera.SetActive(false);

        // 목숨이 0 이하라면 게임 오버
        if (life <= 0)
        {
            GameOver();
            return;
        }

        // 3초 후 플레이어 부활
        StartCoroutine(PlayerReset());
    }

    void GameOver()
    {
        Debug.Log("GameOver");
        isGameOver = true;
    }

    IEnumerator PlayerReset()
    {
        yield return new WaitForSeconds(3);
        
        // 시작지점으로 옮긴 후 플레이어, 카메라 활성화
        player.transform.position = startPosition;
        player.SetActive(true);
        followCamera.SetActive(true);
    }

    IEnumerator TimeLimitCounter()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(0.1f);
            tenthsTicks -= 1;
            
            if (tenthsTicks < 0)
            {
                timeLimit -= 1;
                tenthsTicks = 9;
            }

            if (timeLimit * tenthsTicks < 0 )
            {
                GameOver();
            }
        }
    }
}