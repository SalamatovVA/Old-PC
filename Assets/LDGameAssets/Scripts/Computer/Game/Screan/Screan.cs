using System.Collections;
using UnityEngine;

public class Screan : MonoBehaviour
{
    [SerializeField] EventBus eventBus;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite lagSprite;
    [SerializeField] GameObject screanCanvas;

    [SerializeField] AudioSource audioSource;

    static float _inGameTimeMultiplyer = 1f;
    static float _inGameDeltatime;
    public static float inGameDeltatime => _inGameDeltatime;

    [SerializeField] int baseLagChance;
    [SerializeField] int lagChanceBonuse;
    [SerializeField] int lagChanceIncreasing;
    [SerializeField] int curentLagChance;

    [SerializeField] float maxTimer;
    float timer;


    private void OnEnable()
    {
        eventBus.lagChanceIncrise.AddListener(IncriseLagChance);
        eventBus.lagChanceDecrise.AddListener(DecriseLagChance);
        eventBus.gamePaused.AddListener(PauseGame);
        eventBus.gameUnpoused.AddListener(ContinueGame);
    }
    public void TryLag()
    {
        int result = Random.Range(0, 100);
        if (result > curentLagChance + lagChanceBonuse)
        {
            curentLagChance += lagChanceIncreasing;
        }
        else
        {
            curentLagChance = baseLagChance;
            StartCoroutine(Lag());
        }
    }

    void IncriseLagChance(int added)
    {
        lagChanceBonuse += added;
    }

    void DecriseLagChance(int added)
    {
        lagChanceBonuse -= added;
    }

    public IEnumerator Lag()
    {
        audioSource.Play();
        screanCanvas.SetActive(false);
        _inGameTimeMultiplyer = 0;
        Color baseColor = sprite.color;
        Sprite baseSprite = sprite.sprite;
        sprite.color = Color.darkRed;
        yield return new WaitForSeconds(0.2f);
        sprite.color = baseColor;
        sprite.sprite = lagSprite;
        yield return new WaitForSeconds(0.2f);
        sprite.sprite = baseSprite;
        screanCanvas.SetActive(true);
        _inGameTimeMultiplyer = 1f;
        eventBus.gameLagged.Invoke();
    }

    private void Start()
    {
        curentLagChance = baseLagChance;
    }

    public static void PauseGame()
    {
        _inGameTimeMultiplyer = 0;
    }

    public static void ContinueGame()
    {
        _inGameTimeMultiplyer = 1f;
    }

    private void Update()
    {
        _inGameDeltatime = Time.deltaTime*_inGameTimeMultiplyer;

        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            TryLag();
            timer = 0;
        }
    }

    private void OnDisable()
    {

        eventBus.lagChanceIncrise.RemoveListener(IncriseLagChance);
        eventBus.lagChanceDecrise.RemoveListener(DecriseLagChance);
        eventBus.gamePaused.RemoveListener(PauseGame);
        eventBus.gameUnpoused.RemoveListener(ContinueGame);
    }
}
