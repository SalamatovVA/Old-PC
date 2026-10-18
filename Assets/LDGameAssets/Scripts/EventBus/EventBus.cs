using UnityEngine;
using UnityEngine.Events;
public class EventBus : MonoBehaviour
{
    public UnityEvent gamePaused = new UnityEvent();
    public UnityEvent gameUnpoused = new UnityEvent();
    public UnityEvent gameLagged = new UnityEvent();

    public UnityEvent batteryStartHeating = new UnityEvent();
    public UnityEvent battertStartCooling = new UnityEvent();

    public UnityEvent<int> lagChanceIncrise = new UnityEvent<int>();
    public UnityEvent<int> lagChanceDecrise = new UnityEvent<int>();

    public UnityEvent<string> gameLost = new UnityEvent<string>();
    public UnityEvent gameWon = new UnityEvent();
}
