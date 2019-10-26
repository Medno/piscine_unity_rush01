using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] objects = null;
	[SerializeField] private float spawnDelay = 5f;
	[SerializeField] private bool unique = true;
	private int length;
	private float timer = 0;
	private GameObject spawn = null;
    void Start()
    {
		length = objects.Length;
	}

    void Update()
    {
		if (!unique || spawn == null)
		{
			timer += Time.deltaTime;
			if (timer >= spawnDelay)
			{
				spawn = Instantiate(objects[Random.Range(0, length)], transform);
				spawn.transform.position = gameObject.transform.position;
				timer = 0;
			}
		}
    }
}
