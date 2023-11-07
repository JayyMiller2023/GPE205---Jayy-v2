using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScorePowerup : Powerup
{
    public float scoreToAdd;

    public override void Apply(PowerupManager target)
    {
        Pawn pawn = target.GetComponent<Pawn>();

        if (pawn != null)
        {
            pawn.controller.AddtoScore(scoreToAdd);
        }
    }

    public override void Remove(PowerupManager target)
    {
    }
}
