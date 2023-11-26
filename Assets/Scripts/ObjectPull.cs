using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _poolEnemies = new List<GameObject>();
    private List<GameObject> _poolHeals = new List<GameObject>();

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
        if (Random.Range(1, 11) == 10)
        {
            result = _poolHeals.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }
        else 
        {
            result = _poolEnemies.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }
    }
}
