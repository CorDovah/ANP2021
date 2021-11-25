using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [Header("SpawnOptions")]
    [SerializeField] GameObject[] Enemies;
    public Vector3 SpawnPos;

    public bool enemiesDead;
    public int enemiesKilled;

    private void Start()
    {
        SpawnPos = this.transform.position;
        StartCoroutine("SpawnEnemies");
    }

    void Update()
    {
        if (enemiesKilled >= 3)
        {
            enemiesDead = true;
        }
        else
            enemiesDead = false;


        if (enemiesDead)
        {
            StartCoroutine("SpawnEnemies");
        }
    }

    IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        foreach (var enemy in Enemies)
        {
            Instantiate(enemy, SpawnPos, Quaternion.identity);
            yield return wait;
        }
    }
}
