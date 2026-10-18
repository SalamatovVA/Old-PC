using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] EventBus eventBus;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] int baseTime;
    int currentTime;


    float timerForTimer = 1f;
    float curentTimerForTimer = 0;
    private void OnEnable()
    {
        eventBus.gameLagged.AddListener(AddFixedTime);
    }


    public void ReduseTimer(int time)
    {
        currentTime -= time;
        ChangeTime();
        if (currentTime <= 0)
        {
            eventBus.gameWon.Invoke();
        }
    }
    public void AddFixedTime()
    {
        AddTimer(10);
    }

    public void AddTimer(int time)
    {
        currentTime += time;
        ChangeTime();
    }

    void ChangeTime()
    {
        timerText.text = currentTime.ToString();
    }

    private void Start()
    {
        currentTime = baseTime;
    }

    private void Update()
    {
        curentTimerForTimer += Screan.inGameDeltatime;
        if (curentTimerForTimer > timerForTimer)
        {
            ReduseTimer(1);
            curentTimerForTimer = 0;
        }
    }

    private void OnDisable()
    {
        eventBus.gameLagged.RemoveListener(AddFixedTime);
    }

}
