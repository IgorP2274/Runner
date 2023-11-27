using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _chancePercentHealRespawn;

    private List<GameObject> _poolEnemies = new List<GameObject>();
    private List<GameObject> _poolHeals = new List<GameObject>();
    private float _maxPersentChance = 100;

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _poolEnemies.Add(spawned);
        }
    }

    protected void AddHeals(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _poolHeals.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result) 
    {
        if (Random.Range(0, _maxPersentChance) < _chancePercentHealRespawn)
            result = _poolHeals.FirstOrDefault(p => p.activeSelf == false);
        else 
            result = _poolEnemies.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
