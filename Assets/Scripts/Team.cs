using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {

    public GameObject[] units;
    public int ActionPoint;
    public int maxActionPoint;

    void setAllActive(bool active)
    {
        for (int i = 0; i < units.Length; i++)
            units[i].GetComponent<Unit>().active = active;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
