using UnityEngine;
using ObjectPooling;

public class OnCollision : MonoBehaviour
{
    private int _score;
    private ObjectPool _objectPool;

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<BoxCollider>(out _)) return;

        _score += 1;
        Debug.Log("Бали: " + _score);
        
        _objectPool.ReturnGameObject(other.gameObject);
    }
}