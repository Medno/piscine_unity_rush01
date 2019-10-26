using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
	public enum EquipType
	{
		weapon,
		armor,
	}
	public EquipType type = EquipType.weapon;
	[Header("Modifiers")]
	public int damage = 10;
	public int attackSpeed = 1;
	public int armor = 1;
	public int evasion = 1;
}
