using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyOnDeath : MonoBehaviour
{
    private Health _health;

    // Start is called before the first frame update
    void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDeath += _health_OnDeath;
    }

    private void _health_OnDeath()
    {
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.AddForce(Random.insideUnitSphere * 2, ForceMode.Impulse);
    }

}
