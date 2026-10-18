using UnityEngine;
using UnityEngine.EventSystems;

public class Fan : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] EventBus eventBus;
    [SerializeField] Color baseColor;
    [SerializeField] Color hoverColor;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool isOn = false;

    [SerializeField] int baseOffChance;
    [SerializeField] int offChanceIncreasing;
    [SerializeField] int curentOffChance;

    [SerializeField] float maxTimer;
    float timer;

    void TryOff()
    {
        int result = Random.Range(0, 100);
        if (result > curentOffChance)
        {
            curentOffChance += offChanceIncreasing;
        }
        else
        {
            curentOffChance = baseOffChance;
            SetFan();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetFan();
    }

    void SetFan()
    {
        animator.SetTrigger("On");
        
        isOn = !isOn;
        if (isOn) {
            audioSource.Play();
            eventBus.battertStartCooling.Invoke();
        }
        else
        {
            audioSource.Stop();
            eventBus.batteryStartHeating.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        spriteRenderer.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.color = baseColor;
    }

    private void Update()
    {
        if (isOn)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                TryOff();
                timer = 0;
            }
        }
    }
}
