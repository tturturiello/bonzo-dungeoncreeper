using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvent
{
    /// <summary>
    /// senders: ExitDoor
    /// recievers: GameEnding
    /// </summary>
    public static GameObjectEvent exitReached = new GameObjectEvent();

    /// <summary>
    /// senders: GameEnding
    /// recievers: AudioManager
    /// </summary>
    public static UnityEvent won = new UnityEvent();

    public static GameObjectEvent gotPlayer = new GameObjectEvent();

    /// <summary>
    /// senders: todo characterFell
    /// recievers: RagdollManger
    /// </summary>
    public static FallEvent characterFell = new FallEvent();

    /// <summary>
    /// senders: todo characterFell
    /// recievers: RagdollManger
    /// </summary>
    public static FallEvent characterWokeUp = new FallEvent();

    /// <summary>
    /// senders: Inventory
    /// recievers: 
    /// </summary>
    public static PickUpEvent itemAdded = new PickUpEvent();

    public static PickUpEvent itemDropped = new PickUpEvent();

    /// <summary>
    /// senders: Inventory
    /// recievers: HUD
    /// </summary>
    public static RemoveItemEvent itemRemoved = new RemoveItemEvent();

    /// <summary>
    /// senders: PlayerAdditions
    /// recievers: UIAssistent, Inventory
    /// </summary>
    public static ItemEvent nearItem = new ItemEvent();

    public static UnityEvent trapBuilt = new UnityEvent();

    public static UnityEvent playerDead = new UnityEvent();

    public static UnityEvent playerPOVSwitched = new UnityEvent();


    public static TransitionStateEvent playerLostSight = new TransitionStateEvent();

    public static TransitionStateEvent playerSaw = new TransitionStateEvent();

    public static TransitionStateEvent playerFarAway = new TransitionStateEvent();

    public static TransitionStateEvent playerCloseTo = new TransitionStateEvent();

    public static TransitionStateEvent enemyDead = new TransitionStateEvent();

    public class FallEvent : UnityEvent<GameObject> { }
    public class PickUpEvent : UnityEvent<IInventoryItem> { }
    public class RemoveItemEvent : UnityEvent<int> { }
    public class ItemEvent : UnityEvent<bool, GameObject> { }
    public class TransitionStateEvent : UnityEvent<GameObject> { }
    public class GameObjectEvent : UnityEvent<GameObject> { }
}

