using UnityEngine.Events;

public static class EnemyStateEvent
{
    public static readonly State quiet = new State();

    public static readonly State combact = new State();

    public static readonly State seek = new State();

    public static readonly UnityEvent alert = new UnityEvent();

    public class State : UnityEvent<int> { }
}