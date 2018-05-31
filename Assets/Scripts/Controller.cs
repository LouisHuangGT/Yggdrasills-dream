using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject controllerMenu;
    public State currentState;
    // Use this for initialization


    private void Start()
    {
        controllerMenu.SetActive(false);
    }

    public bool run(GameObject selectedUnit)
    {
        controllerMenu.SetActive(true);
        Unit unit = selectedUnit.GetComponent<Unit>();

        bool result = false;
        switch (currentState)
        {
            case State.IDLE:
                result = false;
                break;
            case State.MOVE:
                result = unit.Move();
                break;
            case State.ATTACK:
                result = unit.Attack();
                break;
            case State.SKILL:
                result = unit.Cast();
                break;
            case State.SUMMON:
                result = unit.Summon();
                break;
            default:
                result = false;
                break;
        }
        if (result == true)
        {
            currentState = State.IDLE;
            controllerMenu.SetActive(false);
        }
        return result;
    }

    

    public void OnClickMove()
    {
        currentState = State.MOVE;
    }
    public void OnClickAttack()
    {
        currentState = State.ATTACK;
    }
    public void OnClickCast()
    {
        currentState = State.SKILL;
    }
    public void OnClickSummon()
    {
        currentState = State.SUMMON;
    }

}
