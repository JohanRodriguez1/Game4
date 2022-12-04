using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenertorController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private GameObject _prefabPowerUp;

    private float Range = 1.2f;
    private int NumberOfEnemies;
    private int NumberOfWaves = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemiesRandom(NumberOfWaves);
        Instantiate(_prefabPowerUp, GenerateRandomPosition(), _prefabPowerUp.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfEnemies = FindObjectsOfType<EnemyFollowing>().Length;

        if (NumberOfEnemies == 0)
        {
            NumberOfWaves++;
            GenerateEnemiesRandom(NumberOfWaves);
            Instantiate(_prefabPowerUp, GenerateRandomPosition(), _prefabPowerUp.transform.rotation);
        }
    }

    void GenerateEnemiesRandom(int GenerateEnemies)
    {
        for (int i = 0; i < GenerateEnemies; i++)
        {
            Instantiate(_prefabEnemy, GenerateRandomPosition(), _prefabEnemy.transform.rotation);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        float PosAxisGenerator = Random.Range(-Range, Range);
        Vector3 RandomPos = new Vector3(PosAxisGenerator, 0, PosAxisGenerator);

        return RandomPos;
    }
}
