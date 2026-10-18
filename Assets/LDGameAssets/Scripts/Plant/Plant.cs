using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Plant : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator plantAnimator;
    [SerializeField] AudioSource plantAudioSource;
    [SerializeField] SpriteRenderer potSprite;
    [SerializeField] Color baseColor;
    [SerializeField] Color hoverColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        plantAnimator.SetTrigger("Jiggle");
        plantAudioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        potSprite.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        potSprite.color = baseColor;
    }
}
