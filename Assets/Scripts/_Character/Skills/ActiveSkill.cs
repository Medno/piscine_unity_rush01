using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActiveSkill : Skill
{
	[System.Serializable]
	public class ActivateEvent : UnityEvent<ActiveSkill>
	{ }
	[SerializeField] protected ActivateEvent OnSkillActivated = null;

	[SerializeField] protected GameObject effectPrefab;
	[SerializeField] protected activeSkillType activeType;

	[SerializeField] protected float cooldown = 0;
	[SerializeField] protected float cost = 0;
	[SerializeField] protected float nextUseTime;
	[SerializeField] protected bool debug_activateSkill = false;
	public GameObject user;
	public GameObject target;

	public virtual void Update()
	{
		if (debug_activateSkill)
		{
			Activate();
			debug_activateSkill = false;
		}
	}
	public enum activeSkillType {
		Healing,
		AOE,
		Ranged,
		Aura
	}
	public virtual void Activate()
	{
		if (nextUseTime < Time.time)
			return;
		nextUseTime = Time.time + cooldown;
		OnSkillActivated.Invoke(this);
	}
}
