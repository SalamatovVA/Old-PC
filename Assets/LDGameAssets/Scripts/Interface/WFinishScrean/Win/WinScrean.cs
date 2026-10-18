using UnityEngine;

public class WinScrean : MonoBehaviour
{
    [SerializeField] EventBus eventBus;
    private void Start()
    {
        //eventBus.gameWon.AddListener(SetWin);
    }

    public void SetWin()
    {
        gameObject.SetActive(true);
    }


}
