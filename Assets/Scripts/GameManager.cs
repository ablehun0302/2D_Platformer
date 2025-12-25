using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    [Header("10 = 1초")]
    [SerializeField] int timeLimit = 200;
    [SerializeField] int life = 3;

    Vector2 startPosition;
    bool isGameOver = false;

    [SerializeField] GameObject player;
    [SerializeField] GameObject followCamera;
    [SerializeField] InGameUI inGameUI;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startPosition = player.transform.position;
        inGameUI.InitLifeViewer(life);
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

        // UI 적용
        inGameUI.DecreaseLife();

        // 목숨이 0 이하라면 게임 오버
        if (life <= 0)
        {
            GameOver();
            return;
        }

        // 3초 후 플레이어 부활
        StartCoroutine(PlayerReset());
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerMovement>().enabled = false;
        Debug.Log("Game Clear!!");
    }

    void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("GameOver");
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
            inGameUI.UpdateTimeText(timeLimit);

            yield return new WaitForSeconds(0.1f);
            timeLimit -= 1;

            if (timeLimit <= 0 )
            {
                GameOver();
                isGameOver = true;
            }
        }
    }
}