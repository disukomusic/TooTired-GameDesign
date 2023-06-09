using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    // goal: be an object or objects on the floor that spawn enemies
    public List<GameObject> enemyPrefab;
    
    [SerializeField] private float subWaitSeconds;
    [SerializeField] private int howManyEnemies;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SubscribeGameManager();
    }

    public void SubscribeGameManager()
    {
        GameManager.Instance.Wave += GameManagerWave;
    }

    private void GameManagerWave(object sender, System.EventArgs e)
    {
        StartCoroutine(SpawnAtTime());
    }


    public void SpawnEnemy()
    {
        _audioSource.Play();
        EnemyPooler.Instance.enemyPrefab.Add(enemyPrefab[Random.Range(0,enemyPrefab.Count)]);
        Enemy enemy = EnemyPooler.Instance.CreateEnemyAtPosition(transform.position);
    }

    public IEnumerator SpawnAtTime()
    {
        // todo find out how to make enemies consistently spawn if there are less active than a certain amount
        // simply checking the list's Count wouldn't work as inactive gameObjects are not removed from the list
        for (int i = 0; i < howManyEnemies + GameManager.Instance.wave; i++)
        {
            yield return new WaitForSeconds(subWaitSeconds);
            SpawnEnemy();
        }
    }
}
