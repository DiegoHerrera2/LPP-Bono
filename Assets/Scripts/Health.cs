using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;

    public event Action OnHit;
    public event Action OnDeath;

    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int dmg)
    {
        OnHit?.Invoke();
        health -= dmg;

        if (health <= 0 && !dead)
        {
            health = 0;
            Death();
        }

    }

    private void Death()
    {
        OnDeath?.Invoke();
        dead = true;
    }

}
