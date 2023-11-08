using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private int _score;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<BoxCollider>(out _)) return;
        
        _score += 1;
        Debug.Log("Бали: " + _score);
        
        Destroy(other.gameObject);
    }
}