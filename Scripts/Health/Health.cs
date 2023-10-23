using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Set health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //if there is no health
        if (currentHealth <= 0)
        {
            //execute this command
            Die(source);
        }

    }

    public void Healing(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        Debug.Log(source.name + " healed " + amount + " points to " + gameObject.name);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //If health is over max...
        if (currentHealth > maxHealth)
        {
            //set it to max
            currentHealth = maxHealth;
        }

    }

    public void Die(Pawn source)
    {
        //Destroy object whenever nessicary
        Destroy(gameObject);
    }
}
