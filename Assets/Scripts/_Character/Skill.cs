using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Skill : MonoBehaviour
{
	public int level = 1;
	public int maxLevel = 5;
	public string skillName = "Skill";
	public skillType type;
    [TextArea] public string tooltip = "";
	public enum skillType
	{
		Active,
		Passive,
	}

	public virtual void LevelUp()
	{}
}
