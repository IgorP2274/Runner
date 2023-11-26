using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    public event UnityAction Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player)) 
            player.ApplayDamage(_damage);

        Die();
    }

    private void Die() =>
        gameObject.SetActive(false);
}
