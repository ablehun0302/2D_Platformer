using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    [Header("10 = 1초")]
    [SerializeField] int timeLimit = 200;
    [SerializeField] int life = 3;
    [SerializeField] float respawnTerm = 3f;

    Vector2 startPosition;

    [SerializeField] GameObject player;
    [SerializeField] GameObject followCamera;
    [SerializeField] GameObject deathAnimation;
    [SerializeField] InGameUI inGameUI;
    [SerializeField] PopupUI popupUI;

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

    public void AddTimeLimit(int time)
    {
        timeLimit += time;
        inGameUI.UpdateTimeText(timeLimit);
    }

    /// <summary>
    /// 플레이어 사망 시 실행
    /// </summary>
    public void PlayerDead()
    {
        // 목숨 감소, 플레이어와 카메라 비활성화
        life -= 1;
        TogglePlayer(false);

        // UI, fx 적용
        inGameUI.DecreaseLife();
        Instantiate(deathAnimation, player.transform.position, Quaternion.identity);
        SoundManager.instance.deathSound.Play();

        // 목숨이 0 이하라면 게임 오버
        if (life <= 0)
        {
            FinishGame(true);
            return;
        }

        // 3초 후 플레이어 부활
        StartCoroutine(PlayerRespawn());
    }

    public void FinishGame(bool isGameOver)
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerMovement>().enabled = false;

        if (isGameOver) timeLimit = 0;

        popupUI.UpdateText(isGameOver, timeLimit);
        Debug.Log("Game Clear!!");
    }

    void TogglePlayer(bool state)
    {
        player.SetActive(state);
        followCamera.SetActive(state);
    }

    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(respawnTerm);
        
        // 시작지점으로 옮긴 후 플레이어, 카메라 활성화
        player.transform.position = startPosition;
        TogglePlayer(true);
    }

    IEnumerator TimeLimitCounter()
    {
        bool state = true;
        while (state)
        {
            inGameUI.UpdateTimeText(timeLimit);

            yield return new WaitForSeconds(0.1f);
            timeLimit -= 1;

            if (timeLimit <= 0 )
            {
                FinishGame(true);
                state = false;
            }
        }
    }
}