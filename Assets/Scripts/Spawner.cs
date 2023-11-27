using UnityEngine;
using System.Collections;

public class Spawner : ObjectPull
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _heal;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform[] _spawnPoints;

    private WaitForSeconds _wait;


    private void Start() 
    {
        Initialize(_enemy);
        AddHeals(_heal);
        _wait = new WaitForSeconds(_spawnDelay);

        StartCoroutine(Create());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    public IEnumerator Create()
    {
        while (true) 
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }

            yield return _wait;
        }
    }

}
