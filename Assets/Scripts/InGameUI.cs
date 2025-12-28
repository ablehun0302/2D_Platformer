using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [Header("남은시간 텍스트 관련")]
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] string timeLeftLabel = "Time Left: ";
    [Header("목숨 이미지 관련")]
    [SerializeField] GameObject lifeViewer;
    [SerializeField] GameObject lifeImage;

    GameObject[] lifeImageList;

    /// <summary>
    /// 남은 시간 텍스트를 변경하는 메서드
    /// </summary>
    /// <param name="time">남은 시간</param>
    public void UpdateTimeText(int time)
    {
        timeText.text = $"{timeLeftLabel}{time/10}";
    }
    
    /// <summary>
    /// 목숨 UI 초기화
    /// </summary>
    /// <param name="life">초반 목숨</param>
    public void InitLifeViewer(int life)
    {
        lifeImageList = new GameObject[life];
        for (life-- ; life >= 0; life--)
        {
            lifeImageList[life] = Instantiate(lifeImage, lifeViewer.transform);
        }
    }

    // 목숨 감소
    public void DecreaseLife()
    {
        for (int index = lifeImageList.Length - 1; index >= 0; index--)
        {
            if (lifeImageList[index].activeInHierarchy)
            {
                lifeImageList[index].SetActive(false);
                return;
            }
        }
    }
}