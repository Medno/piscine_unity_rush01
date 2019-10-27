﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESkill : ActiveSkill
{
	public float AOERadius = 5;
	public float damage = 5;
	[SerializeField] private GameObject AOEGenerator;

	public override void Activate()
	{
		base.Activate();
		GameObject newAOEGenerator = Instantiate(AOEGenerator);
		newAOEGenerator.transform.position = target ? target.transform.position : user.transform.position;
		newAOEGenerator.GetComponent<AOEEffect>().damage = damage;
		newAOEGenerator.GetComponent<AOEEffect>().radius = AOERadius;
		newAOEGenerator.GetComponent<AOEEffect>().particleEffect = Instantiate(effectPrefab);
	}
}