using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChase : State
{
    NPC npc;
    Transform target;
    float timer;

    public StateChase(NPC npc)
    {
        this.npc = npc;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public override void Enter()
    {

    }

    public override void Execute()
    {
        if(CheckTarget())
        {
            timer = 3;
            npc.SetDestination(target.position);
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                npc.SetPatrolState();
        }
    }

    bool CheckTarget()
    {
        RaycastHit hit;
        Vector3 dir = (target.position - npc.transform.position).normalized;
        if(Physics.Raycast(npc.transform.position, dir, out hit, npc.visionRange, npc.visionMask))
        {
            Debug.DrawRay(npc.transform.position, dir * hit.distance, Color.red);
            return hit.transform == target;
        }
        Debug.DrawRay(npc.transform.position, dir * npc.visionRange, Color.green);
        return false;
    }

    public override void Exit()
    {

    }
}
