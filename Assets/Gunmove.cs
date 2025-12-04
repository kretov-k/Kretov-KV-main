using UnityEngine;

public class GunBaseMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _minX = -10f;
    [SerializeField] private float _maxX = 13f;

    void Update()
    {
        float direction = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction = 1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = -1f;

        if (Mathf.Approximately(direction, 0f))
            return;

        Vector3 pos = transform.position;
        pos.x += direction * _moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        transform.position = pos;
    }
}
