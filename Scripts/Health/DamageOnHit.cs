 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{

    public float damageDone;
    public Pawn owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //Getting Health component
        Health otherHealth = other.gameObject.GetComponent<Health>();
        //if it has a health component...
        if (otherHealth != null )
        {
            //Do the damage
            otherHealth.TakeDamage(damageDone, owner);
        }

        //Destroy ourselves whether we did damage or not
        Destroy(gameObject);
    }
}
