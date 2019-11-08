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
	[SerializeField] private int attributePointsPerLevel = 1;
	[SerializeField] private int skillPoints = 0;
	[SerializeField] private int skillPointsPerLevel = 1;
	public GameObject[] activeSkills;
	public GameObject[] passiveSkills;
	private void Awake()
	{
		/* temporary */
		attributePointsPerLevel = 1;
		skillPointsPerLevel = 1;
	}

	public void LevelUp()
	{
		data.level += 1;
		attributePoints += attributePointsPerLevel;
		skillPoints += skillPointsPerLevel;
		GetComponent<Damageable>().SetHealth(data.maxHP);
		GetComponent<ManaPool>().SetMana(data.maxMana);
		OnLevelUp.Invoke(this);
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

	public void Equip(Equippable item)
	{
		data.damageMod += item.damage;
		data.armor += item.armor;
		data.agility += item.evasion;
		data.attackSpeedMod += item.attackSpeed;
	}

	public void Unequip(Equippable item)
	{
		data.damageMod -= item.damage;
		data.armor -= item.armor;
		data.agility -= item.evasion;
		data.attackSpeedMod -= item.attackSpeed;
	}
	public void SwitchEquips(Equippable oldEquip, Equippable newEquip)
	{
		Unequip(oldEquip);
		Equip(newEquip);
	}
	public void UseTalentPoint() {
		skillPoints--;
	}
	public void UseAttributePoint() {
		attributePoints--;
	}
	public int GetSkillsPoints() { return skillPoints; }
	public int GetAttributePoints() {return attributePoints;}
}
