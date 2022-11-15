using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;
    private Transform _player;
    private Health _health;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("PlayerCapsule").transform;
        _health = GetComponent<Health>();
        _health.OnDeath += _health_OnDeath;
    }

    private void _health_OnDeath()
    {
        enabled = false;
    }

    private void Update()
    {
        var direction = (_player.position - _rb.position).normalized;
        _rb.velocity = direction * speed;
    }
}
