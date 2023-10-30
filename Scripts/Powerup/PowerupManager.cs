using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removedPowerupQueue;

    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
        removedPowerupQueue = new List<Powerup>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }

    public void Add(Powerup powerupToAdd)
    {
        powerupToAdd.Apply(this);
        powerups.Add(powerupToAdd);
    }
    public void Remove(Powerup powerupToRemove)
    {
        // Remove the powerup
        powerupToRemove.Remove(this);
        // Add it to the "to be removed queue"
        removedPowerupQueue.Add(powerupToRemove);
    }

    public void DecrementPowerupTimers()
    {
        foreach (Powerup powerup in powerups)
        {
            powerup.duration -= Time.deltaTime;
            if (powerup.duration <= 0)
            {
                Remove(powerup);
            }
        }
    }

    private void ApplyRemovePowerupsQueue()
    {
        // Now that we are sure we are not iterating through "powerups", remove the powerups that are in our temporary list
        foreach (Powerup powerup in removedPowerupQueue)
        {
            powerups.Remove(powerup);
        }
        // And reset our temporary list
        removedPowerupQueue.Clear();
    }
}
