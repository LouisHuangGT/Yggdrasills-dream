using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour {

    
    public bool active = true;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool Move()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        if (agent.remainingDistance < agent.radius && agent.hasPath)
            return true;
        else
            return false;
    }
    public bool Attack()
    {
        Debug.Log(State.ATTACK);
        return true;
    }
    public bool Cast()
    {
        Debug.Log(State.SKILL);
        return true;
    }
    public bool Summon()
    {
        Debug.Log(State.SUMMON);
        return true;
    }
}
