using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuideWindow : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GuideMenu guideMenu;
    [SerializeField] Image guideImage;
    [SerializeField] TextMeshProUGUI guideText;
    [SerializeField] Guide guide;
    int currentPage;

    public void OnPointerClick(PointerEventData eventData)
    {
        currentPage++;
        SetGuide(currentPage);
    }

    public void SetGuide(int page)
    {
        if (guide.guideItems.Length > page)
        {
            if (currentPage != page)
                currentPage = page;
            GuideItem guideItem = guide.guideItems[currentPage];
            guideImage.sprite = guideItem._sprite;
            guideText.text = guideItem._text;
        } else
        {
            guideMenu.CloseMenu(); 
        }
    }
}
