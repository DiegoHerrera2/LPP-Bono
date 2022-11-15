using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShake : MonoBehaviour
{
    public float maxDuration = 0.1f;
    public float angle = 10;
    public Transform playerCameraRoot;

    private Health _health;

    public AudioClip damageSound1;
    public AudioClip damageSound2;
    public AudioClip damageSound3;
    public AudioClip damageSound4;
    List<AudioClip> damageSounds;
    private AudioSource _audio;



    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnHit += _health_OnHit;

        damageSounds = new List<AudioClip>();
        damageSounds.Add(damageSound1);
        damageSounds.Add(damageSound2);
        damageSounds.Add(damageSound3);
        damageSounds.Add(damageSound4);
        _audio = GetComponent<AudioSource>();
    }

    private void _health_OnHit()
    {
        var rotation = playerCameraRoot.transform.localEulerAngles;
        rotation.z = angle;
        playerCameraRoot.transform.localEulerAngles = rotation;
        playerCameraRoot.transform.DOLocalRotate(new Vector3(rotation.x, rotation.y, 0), maxDuration);
        _audio.PlayOneShot(damageSounds[Random.Range(0, 4)], 0.7f);

    }

    void Update()
    {
        
    }
}
