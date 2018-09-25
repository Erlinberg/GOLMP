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

        ObjectsPopulationRules.Add("Oscillator", new int[] { 5, 0, 0});
    }

    // Objects's Functions

    // Glider
    public void CreateGlider()
    {

        // Change rules
        GlobalGod.GetComponent<GlobalGod>().NewLife = ObjectsPopulationRules["Glider"][0];

        GlobalGod.GetComponent<GlobalGod>().OverPopulation = ObjectsPopulationRules["Glider"][1];

        GlobalGod.GetComponent<GlobalGod>().UnderPopulation = ObjectsPopulationRules["Glider"][2];


        // Activate cells
        GlobalGod.GetComponent<GlobalGod>().MainCellArray[272] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[262] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[364] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[363] = 1;

        // Begin simulation
        GlobalGod.GetComponent<GlobalGod>().BeginSimulation = true;

    }

    // Oscillator
    public void CreateOscillator()
    {

        // Change rules
        GlobalGod.GetComponent<GlobalGod>().NewLife = ObjectsPopulationRules["Oscillator"][0];

        GlobalGod.GetComponent<GlobalGod>().OverPopulation = ObjectsPopulationRules["Oscillator"][1];

        GlobalGod.GetComponent<GlobalGod>().UnderPopulation = ObjectsPopulationRules["Oscillator"][2];


        // Activate cells
        GlobalGod.GetComponent<GlobalGod>().MainCellArray[163] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[153] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[154] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[155] = 1;

        GlobalGod.GetComponent<GlobalGod>().MainCellArray[165] = 1;

        // Begin simulation
        GlobalGod.GetComponent<GlobalGod>().BeginSimulation = true;

    }

}
