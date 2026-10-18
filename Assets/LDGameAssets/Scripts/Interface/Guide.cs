using UnityEngine;

[CreateAssetMenu(fileName = "Guide", menuName = "Scriptable Objects/Guide")]
public class Guide : ScriptableObject
{
    [SerializeField] GuideItem[] _guideItems;
    public GuideItem[] guideItems => _guideItems;
}

[System.Serializable]
public class GuideItem
{
    [SerializeField] Sprite sprite;
    public Sprite _sprite => sprite;
    [SerializeField] string text;
    public string _text => text;

}