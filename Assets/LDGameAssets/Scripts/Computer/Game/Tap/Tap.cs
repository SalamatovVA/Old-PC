using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tap : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] EventBus eventBus;
    [SerializeField] Image fillImage;

    [SerializeField] Color baseColor;
    [SerializeField] Color clickColor;
    [SerializeField] Image tapImage;

    [SerializeField] float maxFill;
    [SerializeField] float fillReduction;

    private void Update()
    {
        AddTime(Screan.inGameDeltatime);
    }

    public void AddTime(float added)
    {
        fillImage.fillAmount += added/maxFill;
        if (fillImage.fillAmount > maxFill)
            fillImage.fillAmount = maxFill;
        if (fillImage.fillAmount >= 1)
            eventBus.gameLost.Invoke("You did not tap");
    }

    public void ReduceTime(float reduced)
    {
        fillImage.fillAmount -= reduced / maxFill;
        if (fillImage.fillAmount < 0) 
            fillImage.fillAmount = 0; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ReduceTime(fillReduction);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        tapImage.color = clickColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tapImage.color = baseColor;
    }
}
