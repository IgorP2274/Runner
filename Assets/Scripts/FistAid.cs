using UnityEngine;

public class FistAid : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ApplayDamage(_heal);

        Die();
    }

    private void Die() =>
        gameObject.SetActive(false);
}
