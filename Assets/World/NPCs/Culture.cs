using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culture : MonoBehaviour {
    public Population population;
    public TechTree technology;
    public Resources resources;

	void Start () {
        technology = new TechTree(this);
        population = new Population(this);
        resources = new Resources(this);

		for(int gen = 0; gen < 50; gen++)
        {
            Generation(gen);
        }
	}

    void Generation(int gen)
    {
        resources.food = population.HasJob(Job.Farmer) * 4;
        resources.houses = population.HasJob(Job.Carpenter) * 10;
        resources.land = 25 + population.HasJob(Job.Explorer) * 5;

        if (resources.land > population.Count)
            population.AddPerson("Bob" + gen);

        if(resources.food > population.Count)
            technology.DiscoverRanomTech();

        /*
        Debug.Log("Population = " + population.Count +
            "\nFood = " + resources.food +
            "\nHouses = " + resources.houses +
            "\nLand = " + resources.land);
        */
    }
}
