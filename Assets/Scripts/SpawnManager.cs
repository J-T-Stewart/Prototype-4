using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float spawnRange = 9.0f;

    public GameObject[] enemyPrefabList;
    public GameObject powerupPrefab;

    public int enemyCount;
    public int waveNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        int index = Random.Range(1, enemyPrefabList.Length);
        for (int i = 0; i < enemiesToSpawn; i++) {
            if (i == 0) {
                Instantiate(enemyPrefabList[index], GenerateSpawnPosition(), enemyPrefabList[index].transform.rotation);
            } else {
                Instantiate(enemyPrefabList[0], GenerateSpawnPosition(), enemyPrefabList[0].transform.rotation);
            }
        }
    }
}
