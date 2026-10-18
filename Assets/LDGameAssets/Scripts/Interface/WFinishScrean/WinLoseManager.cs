using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] EventBus eventBus;
    [SerializeField] WinScrean win;
    [SerializeField] LoseScrean lose;

    private void OnEnable()
    {
        eventBus.gameWon.AddListener(SetWin);
        eventBus.gameLost.AddListener(SetLose);
    }

    void SetWin()
    {
        win.SetWin();
    }

    void SetLose(string cuse)
    {
        lose.SetLose(cuse);
    }
}

