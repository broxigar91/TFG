using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective {

    public int id;
    public string description;
    public bool active;
    public bool complete;
    public List<int> requisits;
    public List<int> unlocks;

}

[System.Serializable]
public class ObjectiveDB
{
    public List<Objective> objectives;
}