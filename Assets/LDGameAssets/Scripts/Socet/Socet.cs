using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Socet : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] EventBus eventBus;
    [SerializeField] int lagChanceBonus;

    [SerializeField] Image sparcleImage;
    bool isSparcling;

    [SerializeField] AudioSource audioSource;

    [SerializeField] int baseSparcChance;
    [SerializeField] int sparcChanceIncreasing;
    [SerializeField] int curentSparcChance;

    [SerializeField] float maxTimer;
    float timer;

    private void Start()
    {
        curentSparcChance = baseSparcChance;
    }

    private void Update()
    {
        if (!isSparcling)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                TrySparc();
                timer = 0;
            }
        }
    }

    public void TrySparc()
    {
        int result = Random.Range(0, 100);
        if (result > curentSparcChance)
        {
            curentSparcChance += sparcChanceIncreasing;
        }
        else
        {
            curentSparcChance = baseSparcChance;
            SparclingStateChange();
            audioSource.Play();
            eventBus.lagChanceIncrise.Invoke(lagChanceBonus);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSparcling)
        {
            SparclingStateChange();
            audioSource.Stop();
            eventBus.lagChanceDecrise.Invoke(lagChanceBonus);
        }
    }

    public void SparclingStateChange()
    {
        isSparcling = !isSparcling;
        sparcleImage.enabled = isSparcling;
    }

}
