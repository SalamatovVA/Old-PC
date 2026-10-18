using UnityEngine;


public class Slider : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider slider;
    [SerializeField] EventBus eventBus;
    float currentValue;
    void Update()
    {
        currentValue = slider.value - Screan.inGameDeltatime;
        slider.SetValueWithoutNotify(currentValue);
        if (slider.value <= 0)
            eventBus.gameLost.Invoke("You did not slide");
    }

    public void StopDragDown()
    {
        if (currentValue > slider.value)
        {
            slider.value = currentValue;
        }
        else
        {
            currentValue = slider.value;
        }
    }
}
