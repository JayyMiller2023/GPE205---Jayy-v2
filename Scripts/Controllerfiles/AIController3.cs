using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController3 : Controller
{
    //Public Variables
    public GameObject target;
    public enum AIstates { Guard, Chase, Attack, Patrol, Flee };
    public AIstates currentState;
    public Transform[] waypoints;
    public float waypointStopDistance;
    public float fleeDistance;
    public float fieldOfView;
    public float hearingDistance;

    //Private Variables
    private float lastStateChangeTime;
    private int currentWaypoint = 0;


    public override void Start()
    {
        //start partoling around
        currentState = AIstates.Patrol;
        base.Start();
    }


    public override void Update()
    {
        //Change by using the command
        MakeDecisions();
        base.Update();
    }

    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIstates.Chase:
                //As long as the target exists
                if (target != null)
                {
                    //Activate State
                    DoChaseState();

                    //Requirments must be met in order to change states
                    if (!IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIstates.Guard);
                    }

                    if (IsDistanceLessThan(target, 7))
                    {
                        ChangeState(AIstates.Attack);
                    }

                }

                break;
            case AIstates.Attack:
                //As long as the target exists
                if (target != null)
                {
                    //Activate State
                    DoAttackState();

                    //Requirments must be met in order to change states
                    if (!IsDistanceLessThan(target, 7))
                    {
                        ChangeState(AIstates.Chase);
                    }
                }
                break;
            case AIstates.Guard:
                //As long as the target exists
                if (target != null)
                {
                    //Activate State
                    DoGuardState();

                    //Requirments must be met in order to change states
                    if (IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIstates.Chase);
                    }
                }
                break;
            case AIstates.Patrol:
                //As long as the target exists
                if (target != null)
                {
                    //Activate State
                    DoPatrolState();

                    //Requirments must be met in order to change states
                    if (IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIstates.Chase);
                    }
                }
                break;
        }
    }

    public override void ProcessInputs()
    {
    }

    public void DoGuardState()
    {
    }

    public void DoChaseState()
    {
        if (target != null)
        {
            // Seek our target
            Seek(target);
        }


    }

    public void TargetPlayerOne()
    {
        // If the GameManager exists
        if (GameManager.Instance != null)
        {
            // And the array of players exists
            if (GameManager.Instance.player != null)
            {
                // And there are players in it
                if (GameManager.Instance.player.Count > 0)
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.Instance.player[0].pawn.gameObject;
                }
            }
        }
    }
   
    protected bool IsHasTarget()
    {
        // return true if we have a target, false if we don't
        return (target != null);
    }

    protected void TargetNearestTank()
    {
        // Get a list of all the tanks (pawns)
        Pawn[] allTanks = FindObjectsOfType<Pawn>();

        // Assume that the first tank is closest
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTanks)
        {
            // If this one is closer than the closest
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                // It is the closest
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }

        // Target the closest tank
        target = closestTank.gameObject;
    }

    protected void DoPatrolState()
    {
        //if the waypoint next
        if (waypoints.Length > currentWaypoint)
        {
            //set for the waypoint
            Seek(waypoints[currentWaypoint]);

            //if you reached the waypoint
            if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                //set for the others one by one
                currentWaypoint++;
            }
        }
        //if there is no other waypoint to go to
        else
        {
            //execute this command
            RestartPatrol();
        }
    }

    protected void RestartPatrol()
    {
        //Reset to 0
        currentWaypoint = 0;
    }

    protected virtual void DoAttackState()
    {
        if (target != null)
        {
            //find the target
            Seek(target);
            //execute this command
            Shoot();
        }


    }

    protected void DoFleeState()
    {
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;

        Vector3 vectorAwayFromTarget = -vectorToTarget;

        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;

        Seek(pawn.transform.position + fleeVector);

        float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);

        float percentOfFleeDistance = targetDistance / fleeDistance;

        percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);

        float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;
    }

    public bool CanHear(GameObject target)
    {
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        //if you cant hear it...
        if (noiseMaker == null)
        {
            //return it false
            return false;
        }
        //if you can...
        if (noiseMaker.volumeDistance <= 0)
        {
            //return it true
            return false;
        }

        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanSee(GameObject target)
    {
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);

        if (angleToTarget < fieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Shoot()
    {
        if (pawn != null)
        {
            pawn.Shoot();
        }

    }

    public void Seek(GameObject target)
    {
        if (target != null)
        {
            pawn.RotateTowards(target.transform.position);

            pawn.MoveForward();
        }

    }

    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void ChangeState(AIstates newState)
    {
        currentState = newState;
        lastStateChangeTime = Time.time;
    }

    public void Seek(Vector3 targetPosition)
    {
        //alt: move and rotate towards the position of the player
        pawn.RotateTowards(targetPosition);
        pawn.MoveForward();
    }

    public void Seek(Transform targetTransform)
    {
        //alt: move and rotate towards the point of the player
        Seek(targetTransform.position);
    }

    public void Seek(Pawn targetPawn)
    {
        //Alt: as long as the tank exists...
        if (pawn != null)
        {
            //seek its pawn of the player
            Seek(targetPawn.transform);
        }

    }
}
