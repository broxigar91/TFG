using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkill : Skill {

    public void use()
    {
        // target.hp = (int)(user.intelect / target.mdef * damage);
        Debug.Log("esto hace daño");
    }
}
