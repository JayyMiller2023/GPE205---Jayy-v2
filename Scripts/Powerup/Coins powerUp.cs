using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinspowerUp : MonoBehaviour
{
    public int score;
    public GameObject Coin;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        if (powerupManager != null)
        {
            score = score + 1;
            Destroy(Coin);
        }
    }
}
