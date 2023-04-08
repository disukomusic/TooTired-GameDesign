using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private List<Enemy> objectPool;

    private void Awake()
    {
        objectPool = new List<Enemy>();
    }

    public Enemy CreateGameObject(Vector3 position)
    {
        foreach (var enemy in objectPool)
        {
            // activeInHierachy in case parent is deactivated, as the children would still technically be active
            if (!enemy.gameObject.activeInHierarchy)
            {
                enemy.ResetSelf();
                // reset the gameObject position
                enemy.transform.position = position;
                return enemy;
            }
        }

        GameObject objectToPool = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Enemy newEnemy = objectToPool.GetComponent<Enemy>();
        objectPool.Add(newEnemy);
        return newEnemy;
    }
}