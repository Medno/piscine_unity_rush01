using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSkill : ActiveSkill
{
	public int damage = 5;
	[SerializeField] private float targetOffset_y = 0.25f;
	public override void Activate()
	{
		if (!target)
			return;
		base.Activate();
		Vector3 origin = user.transform.position;
		Vector3 destination = target.transform.position;
		GameObject newEffect = Instantiate(effectPrefab, user.transform);
		newEffect.transform.position = new Vector3(origin.x, origin.y + targetOffset_y, origin.z);
		newEffect.transform.LookAt(new Vector3 (destination.x, destination.y + targetOffset_y, destination.z));
		target.GetComponent<Damageable>().TakeDamage(damage, 100);
	}
}
