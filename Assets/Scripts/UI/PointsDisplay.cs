using TMPro;
using UnityEngine;


public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _score = 0;

    private void Start() =>
        _scoreDisplay.text = "Очки: " + _score.ToString();

    private void OnEnable()=>
        _destroyer.Died += OnDied;

    private void OnDisable() =>
        _destroyer.Died -= OnDied;

    private void OnDied()
    {
        _score += 1;
        _scoreDisplay.text = "Очки: " + _score.ToString();
    }
}
