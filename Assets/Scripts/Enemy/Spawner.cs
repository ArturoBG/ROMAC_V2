using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab; 
    public float timeToSpawn = 1f; //time interval
    public int MaxEnemyCounter = 10; //max number of enemies
    public Transform ClonesFolderParent;

    [SerializeField]
    private int enemyCounter = 0;
    [SerializeField]
    private bool IsSpawning = false;

    private void Start()
    {
        if (IsSpawning)
        {
          SpawnEnemy();
        }        
    }

    public void SpawnEnemy()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (enemyCounter < MaxEnemyCounter)
        {
            Debug.Log("Instantiate enemy...");
            GameObject ork = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            ork.transform.SetParent(ClonesFolderParent);
            yield return new WaitForSeconds(timeToSpawn);
            Debug.Log("Enemy created");
            enemyCounter++;
        }        
    }

}
