using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;

    public event UnityAction<int> ChangeHealth;
    public event UnityAction Died;

    private void Start() 
    {
        _health = _maxHealth;
        ChangeHealth?.Invoke(_health);
    }

    public void ApplayDamage(int damage) 
    { 
        _health -= damage;
        ChangeHealth?.Invoke(_health);

        if (_health <= 0) 
            Die();
    }

    public void ApplayHeal(int heal)
    {
        _health += heal;

        if (_health > _maxHealth)
            _health = _maxHealth;

        ChangeHealth?.Invoke(_health);
    }

    private void Die() =>
        Died?.Invoke();
}
