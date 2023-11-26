using UnityEngine;

public class Spawner : ObjectPull
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _heal;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform[] _spawnPoints;

    private float _passedTime = 0;


    private void Start() 
    {
        Initialize(_enemy);
        AddHeals(_heal);
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _spawnDelay) 
        { 
            if (TryGetObject(out GameObject enemy)) 
            {
                _passedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
