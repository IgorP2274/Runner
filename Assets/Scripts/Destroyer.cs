using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
    public event UnityAction Died;

    private void OnTriggerEnter2D(Collider2D collision) =>
        Died?.Invoke();
}
