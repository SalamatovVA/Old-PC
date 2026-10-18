using UnityEngine;
using UnityEngine.UI;

public class Diode : MonoBehaviour
{
    [SerializeField] float timeBetweenBlincs;
    [SerializeField] float blinckDuration;
    float currentTime = 0;
    bool isOn = true;

    [SerializeField] Image spriteRenderer;
    [SerializeField] Color baseColor;
    [SerializeField] Color blinckColor;


    private void Update()
    {
        currentTime += Time.deltaTime;
        if (isOn)
        {
            if (currentTime >= timeBetweenBlincs)
            {
                spriteRenderer.color = blinckColor;
                currentTime = 0;
                isOn = false;
            }
        }
        else
        {
            if (currentTime >= blinckDuration)
            {
                spriteRenderer.color = baseColor;
                currentTime = 0;
                isOn = true;
            }
        }
    }
}
