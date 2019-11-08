using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{
	public bool isEnabled = false;

    public virtual void Activate() {}
    public virtual void Desactivate() { }
}
