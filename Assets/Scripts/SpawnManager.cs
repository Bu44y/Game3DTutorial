using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float spawnTime = 0f;
    public float delay = 5;

    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= delay)
        {
            GameObject enemyClone = Instantiate(enemy) as GameObject;
            enemyClone.transform.position = new Vector3(Random.Range(-15f, 15f), 0.0f, 20f);
            spawnTime -= delay;
        }
    }
}
