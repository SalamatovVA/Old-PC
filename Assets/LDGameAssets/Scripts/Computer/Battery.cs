using UnityEngine;
using UnityEngine.EventSystems;

public class Battery : MonoBehaviour
{
    [SerializeField] EventBus eventBud;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Color baseColor;
    [SerializeField] Color hotColor;
    [SerializeField] float maxTemperature;
    [SerializeField] float temperature;
    [SerializeField] bool isHeating;

    private void OnEnable()
    {
        eventBud.battertStartCooling.AddListener(coolingState);
        eventBud.batteryStartHeating.AddListener(heatingState);
    }

    public void ColorChange()
    {
        float progress = temperature / maxTemperature;
        spriteRenderer.color = Color.Lerp(baseColor, hotColor, progress);
    }

    public void coolingState()
    {
        isHeating = false;
    }

    public void heatingState()
    {
        isHeating = true;
    }

    public void BrokeBattery()
    {
        eventBud.gameLost.Invoke("There is too hot. Try to use fan.");
    }

    private void Update()
    {
        if (isHeating)
        {
            if (temperature < maxTemperature)
                temperature += Time.deltaTime;
        }
        else
        {
            if (temperature > 0)
                temperature -= Time.deltaTime;
            else temperature = 0;
        }
        ColorChange();
        if (temperature >= maxTemperature)
            BrokeBattery();
        
    }

    private void OnDisable()
    {
        eventBud.battertStartCooling.RemoveListener(coolingState);
        eventBud.batteryStartHeating.RemoveListener(heatingState);
    }

}
