using TMPro;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] EventBus eventBus;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] string pauseText;
    [SerializeField] string unPouseText;

    [SerializeField] GameObject pauseScreen;
    bool isPaused = false;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        pauseScreen.SetActive(isPaused);
        buttonText.text = pauseText;
    }

    public void SetPause()
    {
        if (isPaused)
        {
            isPaused = false;
            buttonText.text = pauseText;
            eventBus.gameUnpoused.Invoke();
            eventBus.gameLagged.RemoveListener(SetPause);
        }
        else
        {
            isPaused = true;
            buttonText.text = unPouseText;
            eventBus.gamePaused.Invoke();
            eventBus.gameLagged.AddListener(SetPause);
        }
        pauseScreen.SetActive(isPaused);
    }

    private void OnDisable()
    {
        
    }

}
