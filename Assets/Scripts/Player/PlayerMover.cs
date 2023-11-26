using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _stepSize;
    [SerializeField] private int _maxHeight;
    [SerializeField] private int _minHeight;

    private Vector3 _targetPosition;

    private void Start() =>
        _targetPosition = transform.position;

    private void Update()
    {
        if (_targetPosition != transform.position) 
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoveUp() 
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPositoon(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPositoon(- _stepSize);
    }

    public void SetNextPositoon(int stepSize) =>
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
}
