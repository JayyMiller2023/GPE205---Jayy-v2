using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinspowerUp : MonoBehaviour
{
    public ScorePowerup powerup;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)
        {
            powerupManager.Add(powerup);

            Destroy(gameObject);
        }
    }
}
