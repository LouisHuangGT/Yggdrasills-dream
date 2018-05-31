using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    Controller controller;

    public GameObject selectedUnit;

    public Team[] team;
    public int currenTeamIndex = 0;

	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (selectedUnit != null)
        {
            if (controller.run(selectedUnit))
            {
                team[currenTeamIndex].ActionPoint--;
                selectedUnit = selectUnit();
            }
        }
        else
            selectedUnit = selectUnit();
        if (team[currenTeamIndex].ActionPoint <= 0)
        {
            team[currenTeamIndex].ActionPoint = team[currenTeamIndex].maxActionPoint;
            currenTeamIndex = 1 - currenTeamIndex;
        }
    }

    GameObject selectUnit()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (isIn(hit.transform.gameObject, team[currenTeamIndex].units))
                    return hit.transform.gameObject;
                else
                    return null;
            }
            else
                return null;
        }
        else
            return null;
    }
    bool isIn(GameObject target, GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
            if (target == array[i])
                return true;
        return false;
    }
}
