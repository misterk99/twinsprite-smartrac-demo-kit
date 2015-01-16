using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utils 
{
	private static List<GameObject> livingEnemies = new List<GameObject>();

	public static List<GameObject> GetLivingEnemies()
	{
		return livingEnemies;
	}

	public static void AddLivingEnemy(GameObject newEnemy)
	{
		if (!livingEnemies.Contains(newEnemy))
		{
			livingEnemies.Add(newEnemy);
		}
	}

	public static void RemoveLivingEnemy(GameObject deadEnemy)
	{
		if (livingEnemies.Contains(deadEnemy))
		{
			livingEnemies.Remove(deadEnemy);      
		}
	}
}
