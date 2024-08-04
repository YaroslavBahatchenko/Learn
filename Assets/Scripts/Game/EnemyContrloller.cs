using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SingletonMono<EnemyController>
{
    private List<Enemy> enemies = new List<Enemy>();

    public void AddEnemy(Enemy newEnemy)
    {
        enemies.Add(newEnemy);
    }

    public void RemoveEnemy(Enemy enemyToRemove)
    {
        enemies.Remove(enemyToRemove);
        if (enemies.Count == 0)
        {
            Debug.Log("Player Win!");
        }
    }
}
