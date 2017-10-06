using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Population {

    private Culture _culture;
    private List<Person> _people = new List<Person>();

    public List<Job> AvailableJobs = new List<Job>{ Job.Unemployed, Job.Farmer, Job.Carpenter };
    public int Count { get { return _people.Count(); } }

    public Population (Culture culture) {
        _culture = culture;
        _people.Add(new Person { name = "Adam", job = Job.Carpenter });
        _people.Add(new Person { name = "Eve", job = Job.Farmer });
    }

    public void AddPerson(string name)
    {
        var job = NeededJob();
        _people.Add(new Person { name = name, job = job });
        Debug.Log("Pop: "+name + " was born a " + job);
    }
    public void KillPerson(string name)
    {
        _people.Remove(_people.Where(x => x.name == name).FirstOrDefault());
    }

    public Job RandomSpecialty()
    {
        if (AvailableJobs.Count() > 3)
            return AvailableJobs.ElementAt(Random.Range(3, AvailableJobs.Count()));
        else
            return Job.Farmer;
    }
    public Job NeededJob()
    {
        if (_culture.resources.food < Count)
            return Job.Farmer;
        else if (_culture.resources.houses < Count / 3)
            return Job.Carpenter;
        else 
            return RandomSpecialty();
    }

    public int HasJob(Job job)
    {
        int rtn = 0;
        foreach(Person p in _people)
            if (p.job == job) rtn++;
        return rtn;
    }

}

public struct Person
{
    public string name;
    public Job job;
}

public enum Job
{
    Unemployed,
    Farmer,
    Carpenter,
    Blacksmith,
    Explorer,
    Stableman,
    Merchant,
    Soldier,
    ShipBuilder,
    Nobleman
}