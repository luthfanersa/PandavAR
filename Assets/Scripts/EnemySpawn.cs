using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(5);

        for(int i = 0; i < 5; i++)
        {
            Instantiate(enemies[i], spawnPoints[i].position, Quaternion.identity);
        }

        StartCoroutine(StartSpawning());
    }
}
