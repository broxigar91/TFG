using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkill : MonoBehaviour {

    public string abilityName;
    public string description;
    public int damage;
    public string job;
    public Unit target;
    public Unit user;

    public void use()
    {
        // target.hp = (int)(user.intelect / target.mdef * damage);
        Debug.Log("esto hace daño");
    }
}
