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
	public class XPGainEvent : UnityEvent<Hero>
	{ }

	[Header("Leveling")]
	[SerializeField] private LevelUpEvent OnLevelUp = null;
	[SerializeField] private XPGainEvent OnXPGain = null;
	public void LevelUp()
	{
		OnLevelUp.Invoke(this);
	}

	public void GainXP(int amount)
	{
		data.xp += amount;
		OnXPGain.Invoke(this);
		if (data.xp >= data.xpToNextLevel)
		{
			data.xp -= data.xpToNextLevel;
			/* temporary */ data.xpToNextLevel *= 2;
			LevelUp();
		}
	}
}
