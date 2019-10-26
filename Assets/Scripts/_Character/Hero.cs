using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : Character
{
	[System.Serializable]
	public class LevelUpEvent : UnityEvent<Hero>
	{ }

	[System.Serializable]
	public class XPGainEvent : UnityEvent<Hero, float>
	{ }

	[SerializeField] private LevelUpEvent OnLevelUp = null;
	[SerializeField] private XPGainEvent OnXPGain = null;
	[SerializeField] private int attributePoints = 0;
	[SerializeField] private int attributePointsPerLevel = 0;
	[SerializeField] private int skillPoints = 0;
	[SerializeField] private int skillPointsPerLevel = 0;
	public ActiveSkill[] activeSkills;

	private void Start()
	{
		/* temporary */
		foreach (ActiveSkill heroSkill in activeSkills)
		{
			heroSkill.user = this.gameObject;
		}
	}
	public void LevelUp()
	{
		OnLevelUp.Invoke(this);
		attributePoints += attributePointsPerLevel;
		skillPoints += skillPointsPerLevel;
	}

	public void GainXP(int amount)
	{
		data.xp += amount;
		OnXPGain.Invoke(this, amount);
		while (data.xp >= data.xpToNextLevel)
		{
			data.xp -= data.xpToNextLevel;
			/* temporary */
			data.xpToNextLevel *= 2;
			LevelUp();
		}
	}
}
