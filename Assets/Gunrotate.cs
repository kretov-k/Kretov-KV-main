using UnityEngine;

public class GunBarrelRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 45f;
    [SerializeField] private float _minX = -90f;  
    [SerializeField] private float _maxX = -45f;  

    private float _currentX;

    void Start()
    {
        _currentX = transform.localEulerAngles.x;
        if (_currentX > 180f)
            _currentX -= 360f;
    }

    void Update()
    {
        float input = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            input = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            input = -1f;

        if (Mathf.Approximately(input, 0f))
            return;

        _currentX += -input * _rotationSpeed * Time.deltaTime;

        _currentX = Mathf.Clamp(_currentX, _minX, _maxX);

        Vector3 angles = transform.localEulerAngles;
        angles.x = _currentX;
        transform.localEulerAngles = angles;
    }
}
