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
	public PassiveSkill[] passiveSkills;
	public int damage = 0;
	private void Start()
	{
		/* temporary */
		foreach (ActiveSkill heroSkill in activeSkills)
		{
			heroSkill.user = this.gameObject;
		}
		foreach (PassiveSkill heroSkill in passiveSkills)
		{
			heroSkill.user = this.gameObject;
		}
	}

	public void LevelUp()
	{
		OnLevelUp.Invoke(this);
		data.level += 1;
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

	public void Equip(Equippable item)
	{
		data.damageBoost += item.damage;
		data.armor += item.armor;
		data.agility += item.evasion;
		if (item.type == Equippable.EquipType.weapon)
			data.attackSpeed = item.attackSpeed;
	}

	public void Unequip(Equippable item)
	{
		data.damageBoost -= item.damage;
		data.armor -= item.armor;
		data.agility -= item.evasion;
		if (item.type == Equippable.EquipType.weapon)
			data.attackSpeed = 1;
	}
	public void SwitchEquips(Equippable oldEquip, Equippable newEquip)
	{
		Unequip(oldEquip);
		Equip(newEquip);
	}
	public void UseTalentPoint() {
		skillPoints--;
	}
	public int GetSkillsPoints() { return skillPoints; }
}
