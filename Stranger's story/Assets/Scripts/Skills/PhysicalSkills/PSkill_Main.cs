using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSkill_Main : Skill
{
    private float physicalMultiplier;
    private float magicalMultiplier;

    public PSkill_Main(float PMultiplier, float MMultiplier): base("Base attack", "Physical"){
        physicalMultiplier = PMultiplier;
        magicalMultiplier = MMultiplier;
    }

    public override int  DealDamage(UnitStatus attacker, UnitStatus defender){
        
        return 10;
    }
    
    

}
