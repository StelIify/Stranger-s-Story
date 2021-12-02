using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    string skillName;
    string skillType;

    public Skill(string name, string type){
        skillName = name;
        skillType = type;
    }

    public virtual int  DealDamage(UnitStatus attacker, UnitStatus defender){
        return 1;
    }

    public string GetSkillName(){
        return skillName;
    }

    public string GetSkillType(){
        return skillType;
    }
    
}
