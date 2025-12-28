using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupUI : MonoBehaviour
{
    [Header("타이틀 텍스트 관련")]
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] string clearText;
    [SerializeField] string gameOverText;

    [Header("스코어 관련")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] string scoreLabel = "Your score: ";

    [Header("버튼")]
    [SerializeField] Button restartButton;

    void Start()
    {
        // 버튼 바인딩
        restartButton.onClick.AddListener(Restart);
    }

    public void UpdateText(bool isGameOver, int timeLimit)
    {
        gameObject.SetActive(true);

        if (!isGameOver) { titleText.text = clearText; }
        else            { titleText.text = gameOverText; }

        scoreText.text = $"{scoreLabel}{timeLimit/10f}";
    }

    void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
