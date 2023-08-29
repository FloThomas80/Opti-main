using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyPrefabs;
    private List<GameObject> EnemySpawnPoints = new List<GameObject>();

    void Start()
    {
        EnemySpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("EnemySpawnPoint"));
        for (int i = 0; i < EnemySpawnPoints.Count; i++)
        {
            Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)],
                EnemySpawnPoints[i].transform.position,
                EnemySpawnPoints[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // vérification si un enemy est mort et le cas échéant en faire spawn un nouveau à une position aléatoire
        // pour cela on compare le nombre théorique d'enemy avec le nombre actuel
        while (EnemySpawnPoints.Count > GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            int RandomNumber = Random.Range(0, EnemyPrefabs.Count);
            Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)],
                EnemySpawnPoints[RandomNumber].transform.position,
                EnemySpawnPoints[RandomNumber].transform.rotation);
        }
    }
}
