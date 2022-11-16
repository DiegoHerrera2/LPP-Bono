using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null) health.Damage(damage);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(-transform.right, rotationSpeed * Time.deltaTime);
    }
}
