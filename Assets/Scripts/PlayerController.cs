using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Transform _transform;
    private float _screenWidth;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        if (Camera.main != null) 
            _screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            float movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            _transform.position += new Vector3(movement, 0, 0);
        }

        var position = _transform.position;
        position = new Vector3(Mathf.Clamp(position.x, -_screenWidth, _screenWidth), position.y, position.z);
        _transform.position = position;
    }
}