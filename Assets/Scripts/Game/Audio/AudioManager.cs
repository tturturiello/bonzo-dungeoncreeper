using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Game sounds")]
    [SerializeField] private AudioSource won;
    [SerializeField] private AudioSource trumpet;

    [Header("Objects")]
    [SerializeField] private AudioSource doorOpened;

    [Header("Enemy")]
    [SerializeField] private AudioSource enemyDeath;
    [SerializeField] private AudioSource enemyAware;
    [SerializeField] private AudioSource spearHitEnemyFX;

    [Header("Weapons")]
    [SerializeField] private AudioSource axeAudio;
    [SerializeField] private AudioSource spearThrownAudio;
    [SerializeField] private AudioSource spearHitAudio;

    void Awake()
    {
        GameEvent.won.AddListener(won.Play);

        GameEvent.enemyDead.AddListener(owner 
            => PlayOnPosition(owner.transform.position, enemyDeath));

        GameEvent.playerSaw.AddListener(owner
            => PlayOnPosition(owner.transform.position, enemyAware));

        AudioEvent.axeHit.AddListener(owner
            => PlayOnPosition(owner.transform.position, axeAudio));

        AudioEvent.spearThrown.AddListener(owner
            => PlayOnPosition(owner.transform.position, spearThrownAudio));

        AudioEvent.spearHitEnemyFX.AddListener(owner
            => PlayOnPosition(owner.transform.position, spearHitEnemyFX));

        AudioEvent.spearHit.AddListener(owner
            => PlayOnPosition(owner.transform.position, spearHitAudio));

        AudioEvent.doorOpened.AddListener(owner
            => PlayOnPosition(owner.transform.position, doorOpened));

        AudioEvent.doorOpened.AddListener(owner
            => trumpet.Play());
    }

    void PlayOnPosition(Vector3 desiredPosition, AudioSource source)
    {
        source.transform.position = desiredPosition;
        source.Play();

        Debug.Log(source.name);
    }

    public static class AudioEvent
    {
        public static Audio spearThrown = new Audio();

        public static Audio spearHit = new Audio();

        public static Audio spearHitEnemyFX = new Audio();

        public static Audio axeHit = new Audio();

        public static Audio hammerHit = new Audio();

        public static Audio doorOpened = new Audio();

        public class Audio : UnityEvent<GameObject> { }
    }

}
