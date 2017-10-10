using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TechTree{

    private readonly Culture _culture;

    public List<Tech> DiscoveredTechnologies = new List<Tech>();
    public int NumTechnologies
    {
        get { return DiscoveredTechnologies.Count; }
    }


    public TechTree(Culture culture)
    {
        _culture = culture;
    }

    private List<Tech> AvailableTechnologies = new List<Tech>()
    {
        new Tech("Map", new string[] {}, Job.Explorer),
        new Tech("Fighting", new string[] {}),
        new Tech("Weapons", new [] { "Fighting" } , Job.Blacksmith),
        new Tech("Roads", new [] { "Map" }),
        new Tech("Mounts", new [] { "Roads" }, Job.Stableman),
        new Tech("Boats",new [] { "Mounts" }, Job.ShipBuilder),
        new Tech("Trade",new [] { "Roads" }, Job.Merchant),
        new Tech("Currency", new [] { "Trade" }),
        new Tech("Governements", new [] { "Currency" }, Job.Nobleman),
        new Tech("Militia", new [] { "Governements", "Weapons" }, Job.Soldier),
    };

    public Tech DiscoverTech(string techName) // you should be able to rename techs
    {
        if (AvailableTechnologies.Count == 0) return null;

        var dTech = AvailableTechnologies.SingleOrDefault(x => x.Name == techName);

        foreach(var aTech in AvailableTechnologies)
        {
            if (aTech.Prerequisites.Contains(techName))
            {
                aTech.Prerequisites = aTech.Prerequisites.Where(x => x != techName);
            }
        }

        AvailableTechnologies.Remove(dTech);
        DiscoveredTechnologies.Add(dTech);

        if(dTech.Job != Job.Unemployed)
            _culture.population.AvailableJobs.Add(dTech.Job);

        //Debug.Log("Tech: Discovered " + dTech.Name);

        return dTech;
    }

    public Tech DiscoverRanomTech()
    {
        var aTechs = AvailableTechnologies.Where(x => !x.Prerequisites.Any());

        if (!aTechs.Any()) return null;

        var t = aTechs.ElementAt(Random.Range(0, aTechs.Count()));

        return DiscoverTech(t.Name);
    }

}

public class Tech
{
    public string Name;
    public IEnumerable<string> Prerequisites;
    public Job Job;

    public Tech(string name, IEnumerable<string> prerequisites, Job job = Job.Unemployed)
    {
        Job = job;
        Name = name;
        Prerequisites = prerequisites;
    }
}
