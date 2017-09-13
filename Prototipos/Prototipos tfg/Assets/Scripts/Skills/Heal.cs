using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    public string abilityName;
    public string description;
    public int heal;
    public string job;
    public Unit target;
    public Unit user;

    
    public void use()
    {
        Debug.Log("esto cura");
    }
}
