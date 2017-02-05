using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobTest : Job_Base {
    
    public JobTest()
    {
        JobName = "Test1";
        JobDescription = "Esto es un testeo de jobs";
        Hp = 0;
        Str = 0.5f;
        Def = 0;
        Intelect = -0.5f;
        Mdef = 0.2f;
        Spe = 0;
    }

}
