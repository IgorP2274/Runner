using TMPro;
using UnityEngine;


public class PointsDisplay : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private TMP_Text _ScoreDisplay;

    private int _score = 0;


    private void Start()
    {
        _ScoreDisplay.text = _score.ToString();
    }

    private void OnEnable()
    {
        _destroyer.Died += OnDied;
    }

    private void OnDisable()
    {
        _destroyer.Died -= OnDied;
    }

    private void OnDied()
    {
        _score += 1;
        _ScoreDisplay.text = _score.ToString();
    }
}
