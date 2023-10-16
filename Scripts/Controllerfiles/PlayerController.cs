using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerController : Controller
{

    public KeyCode MoveForwardKey;
    public KeyCode MoveBackwardKey;
    public KeyCode RotateClockwiseKey;
    public KeyCode RotateCounterClockwiseKey;

    // Start is called before the first frame update
    public override void Start()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.player != null)
            {
                GameManager.Instance.player.Add(this);
            }
        }

        //Run from start in Controller.cs
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Process inputs
        ProcessInputs(); //To be implemented

        base.Update();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(MoveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(MoveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(RotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(RotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }

    public void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.player != null)
            {
                GameManager.Instance.player.Remove(this);
            }
               
        }
    }
}
