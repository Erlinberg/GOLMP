using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour {

    private Dictionary<string, int[]> ObjectsPopulationRules = new Dictionary<string, int[]>(1);

    private GameObject GlobalGod;



    private void Start()
    {
        // Init Controller
        GlobalGod = GameObject.Find("GlobalGod");

        // Init dictionary of rules
        ObjectsPopulationRules.Add("Glider", new int[] {3, 0, 0});
	}

    // Objects's Functions

    // Glider
    public void CreateGlider()
    {

        GlobalGod.GetComponent<GlobalGod>().NewLife = ObjectsPopulationRules["Glider"][0];

        GlobalGod.GetComponent<GlobalGod>().OverPopulation = ObjectsPopulationRules["Glider"][1];

        GlobalGod.GetComponent<GlobalGod>().UnderPopulation = ObjectsPopulationRules["Glider"][2];

    }

}
