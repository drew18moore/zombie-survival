using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnInterval = 5f;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval));
    }

    IEnumerator spawnEnemy(float interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval));
    }
}
