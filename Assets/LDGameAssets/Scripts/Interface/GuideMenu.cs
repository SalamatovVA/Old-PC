using UnityEngine;
using UnityEngine.EventSystems;

public class GuideMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GuideWindow guideWindow;
    int currentPage = 0;
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        guideWindow.SetGuide(0);
    }

    public void CloseMenu() {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CloseMenu();
    }
}
