using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModEffect : MonoBehaviour
{
	private GameObject target;
	[Header("Mod")]
	public ModType modType;
	[SerializeField] private int modAmount = 1;
	private int currentmod = 0;
	private bool isPercentageBased = false;
	public enum ModType
	{
		strength,
		armor,
		evasion,
		attackSpeed,
	}
	void Start()
    {
		target = transform.parent.gameObject;
		switch (modType)
		{
			case ModType.strength:
				{
					currentmod = isPercentageBased ? (1 / target.GetComponent<CharacterData>().strength) * (100 + modAmount) : modAmount;
					target.GetComponent<CharacterData>().strength += modAmount;
					break;
				}
			case ModType.armor:
				{
					currentmod = isPercentageBased ? (1 / target.GetComponent<CharacterData>().armor) * (100 + modAmount) : modAmount;
					target.GetComponent<CharacterData>().armor += modAmount;
					break;
				}
			case ModType.evasion:
				{
					currentmod = isPercentageBased ? (1 / target.GetComponent<CharacterData>().agility) * (100 + modAmount) : modAmount;
					target.GetComponent<CharacterData>().agility += modAmount;
					break;
				}
			case ModType.attackSpeed:
				{
					target.GetComponent<CharacterData>().attackSpeedMod += modAmount;
					break;
				}
		}
	}
}
