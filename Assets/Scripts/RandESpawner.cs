using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    // for debug :
    public string Name;

    public GameObject Prefab;
    [Range(0f, 100f)] public float Chance = 100f;
 
    [HideInInspector] public double _weight;
}


public class RandESpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;

    private double accumulatedWeights;
    private System.Random rand = new System.Random();


    private void Awake()
    {
        CalculateWeights();
    }


    private void Start()
    {

        // Test: Spawn 4 wave 
        for (int i = 0; i < 3; i++)
        {

            StartCoroutine(SpawnWave());
            
            
        }
        
    }

    private void SpawnRandomEnemy(Vector3 position)
    {
        Enemy randomEnemy = enemies[GetRandomEnemyIndex()];
        Instantiate(randomEnemy.Prefab, position, Quaternion.identity, transform);

        // This line is not required (debug) :
        Debug.Log("<color=" + randomEnemy.Name + ">●</color> Chance: <b>" + randomEnemy.Chance + "</b>%");
    }

    private int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < enemies.Length; i++)
            if (enemies[i]._weight >= r)
                return i;

        return 0;
    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (Enemy enemy in enemies)
        {
            accumulatedWeights += enemy.Chance;
            enemy._weight = accumulatedWeights;
        }
    }

    public IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 2; i++)
        {

            SpawnRandomEnemy(new Vector3(Random.Range(-3f, 4f), -1f, Random.Range(4f, 10f)));

        }
        StartCoroutine(SpawnWave());
    }

}