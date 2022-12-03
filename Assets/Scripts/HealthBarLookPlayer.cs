using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLookPlayer : MonoBehaviour
{
    private Transform _player;

    private void Awake()
    {

        _player = GameObject.Find("PlayerCapsule").transform;

    }

    private void Update()
    {
        var direction = (_player.position - transform.position);
        direction.Normalize();
        transform.rotation = Quaternion.LookRotation(direction);
    }
}