using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSkill : Skill {

    public enum Type
    {
        DEAL,
        HEAL
    }

    public Type type;

    public void use()
    {
        switch(type)
        {
            case Type.DEAL:
                break;
            case Type.HEAL:
                break;
        }
    }
}
