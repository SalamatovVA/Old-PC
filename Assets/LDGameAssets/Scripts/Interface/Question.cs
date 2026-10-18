using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Question : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image myImage;
    [SerializeField] GuideMenu guideMenu;

    private void Start()
    {
        guideMenu.OpenMenu();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        guideMenu.OpenMenu();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myImage.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myImage.color = Color.white;
    }
}
