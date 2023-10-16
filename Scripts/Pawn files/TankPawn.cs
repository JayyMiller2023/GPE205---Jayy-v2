using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }

    public override void MoveForward()
    {
        //to move forward!
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        //to move backwards!
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        //to Rotate to the left!
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        //to Rotate to the right!
        mover.Rotate(-turnSpeed);
    }
}
