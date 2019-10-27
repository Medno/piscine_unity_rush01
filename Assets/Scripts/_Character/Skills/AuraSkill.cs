using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSkill : ActiveSkill
{
	public int dps = 10;
	public float duration = 5;
	public override void Activate()
	{
		base.Activate();
		GameObject newEffect = Instantiate(effectPrefab, user.transform);
		newEffect.GetComponent<AuraEffect>().dps = dps;
		newEffect.GetComponent<AuraEffect>().duration = duration;
	}
}
