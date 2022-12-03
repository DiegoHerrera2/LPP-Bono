using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;
    private Transform _player;

    [SerializeField]
    private Health _health;

    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("PlayerCapsule").transform;
        _health.OnDeath += _health_OnDeath;
    }

    private void _health_OnDeath()
    {
        enabled = false;
        _animator.SetBool("dead", true);
    }

    private void Update()
    {
        var direction = (_player.position - _rb.position);
        direction.y = 0;
        _animator.SetBool("attacking", (direction.magnitude < 8));
        direction.Normalize();
        _rb.velocity = direction * speed;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
