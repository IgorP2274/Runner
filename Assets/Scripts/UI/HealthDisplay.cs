using TMPro;
using UnityEngine;


public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthDisplay;


    private void OnEnable()
    {
        _player.ChangeHealth += OnHealthChange;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= OnHealthChange;
    }

    private void OnHealthChange(int health) 
    {
        _healthDisplay.text = "Çהמנמגüו: " + health.ToString();
    }
}
