using TMPro;
using UnityEngine;

public class LoseScrean : MonoBehaviour
{
    [SerializeField] EventBus eventBus;
    [SerializeField] TextMeshProUGUI textField;
    private void Start()
    {
        //eventBus.gameLost.AddListener(SetLose);
    }

    public void SetLose(string cuse)
    {
        gameObject.SetActive(true);
        textField.text = $"Cuse of lose: {cuse}";
    }
}
