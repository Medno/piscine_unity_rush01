﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject target;
	[SerializeField] private float attackRadius = 5;
	[SerializeField] private float attackDelay = 3;
	[SerializeField] private float nextAttackTime = 0;

	private Animator animator;
	private NavMeshAgent agent;
	private Hero character;

	private void Start()
	{
		character = GetComponent<Hero>();
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (agent.remainingDistance < agent.stoppingDistance && animator.GetBool("run") == true)
		{
			animator.SetBool("run", false);
		}
		if (target)
		{
			transform.LookAt(target.transform.position);
			float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
			if (distanceToTarget <= attackRadius)
			{
				if (Time.time > nextAttackTime)
				{
					animator.SetBool("attack", true);
					animator.SetBool("run", false);
					agent.isStopped = true;
					agent.ResetPath();
					nextAttackTime = Time.time + attackDelay;
				}
			}
		}
	}
	public void moveTo(Vector3 newDestination)
	{
		transform.LookAt(newDestination);
		agent.destination = newDestination;
		animator.SetBool("run", true);
	}
	public void DealDamage()
	{
		if (!target)
			return;
		if (target.GetComponent<Damageable>().currentHealth > 0)
		{
			target.GetComponent<Damageable>().TakeDamage(character.computeDamage(), character.computeHitChance());
		}
		if (target.GetComponent<Damageable>().currentHealth <= 0)
		{
			resetTarget();
		}
		if (!Input.GetMouseButton(0))
		{
			resetTarget();
		}
	}
	public GameObject getTarget()
	{
		return (target);
	}
	public void setTarget(GameObject newTarget)
	{
		target = newTarget;
		transform.LookAt(newTarget.transform.position);
		agent.destination = newTarget.transform.position;
		animator.SetBool("run", true);
	}
	public void resetTarget()
	{
		animator.SetBool("attack", false);
		animator.SetBool("run", false);
		agent.isStopped = true;
		agent.ResetPath();
		target = null;
	}
	public void OnDie()
	{
		animator.SetTrigger("death");
		agent.isStopped = true;
		agent.ResetPath();
		target = null;
	}
}
