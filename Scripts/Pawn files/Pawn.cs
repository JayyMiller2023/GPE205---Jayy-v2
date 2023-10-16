using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //Changes the speed for moving
    public float moveSpeed;
    //Changes the speed for turning
    public float turnSpeed;
    //Rate of Fire
    public float fireRate;
    //hold Mover as a Variable
    public Mover mover;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
