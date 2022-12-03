using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    public int damage;
    public float cooldown;

    private float _lastFrameHit;


    private void Awake()
    {


    }
    private void OnTriggerStay(Collider other)
    {
        if (Time.time > _lastFrameHit)
        {
            var health = other.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage);
                _lastFrameHit = Time.time + cooldown;
            }
        }
    }

}
