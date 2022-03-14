using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : State
{
    NPC npc;
    Transform[] patrolPoints;
    int currentPoint;
    float timer;
    bool pointReached;

    public StatePatrol(NPC npc, Transform[] points)
    {
        patrolPoints = points;
        this.npc = npc;
        currentPoint = 0;
    }

    public override void Enter()
    {
        timer = 3;
        npc.SetDestination(patrolPoints[currentPoint].position);
    }

    public override void Execute()
    {
        if(CheckVision())
        {
            npc.SetChaseState(npc.player);
            return;
        }

        pointReached = Vector3.Distance(npc.transform.position, patrolPoints[currentPoint].position) < .5f;
        if(pointReached && timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SetNextPoint();
            }
        }
    }

    bool CheckVision()
    {
        RaycastHit hit;
        Vector3 dir = npc.transform.forward;
        if(Physics.Raycast(npc.transform.position, dir, out hit, npc.visionRange, npc.visionMask))
        {
            Debug.DrawRay(npc.transform.position, dir * hit.distance, Color.red);
            return hit.transform == npc.player;
        }
        Debug.DrawRay(npc.transform.position, dir * npc.visionRange, Color.green);
        return false;
    }

    void SetNextPoint()
    {
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        timer = 3f;
        npc.SetDestination(patrolPoints[currentPoint].position);
    }

    public override void Exit()
    {

    }
}
