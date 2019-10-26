using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSkill : ActiveSkill
{
    [Header("Healing")]
	public int healAmount = 1;
    public bool isPercentageBased = false;

    public override void TriggerEffect()
	{
        Damageable userDamageable = user.GetComponent<Damageable>();
        userDamageable.GainHealth(isPercentageBased ? (userDamageable.currentHealth / userDamageable.maxHealth) * (100 + healAmount) : healAmount);
	}
}
