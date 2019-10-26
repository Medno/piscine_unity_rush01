using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSkill : ActiveSkill
{
	public int healAmount;
    public override void TriggerEffect()
	{
		user.GetComponent<Damageable>().GainHealth(healAmount);
	}
}
