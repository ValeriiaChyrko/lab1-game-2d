using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class ObjectPool : MonoBehaviour
    {
        // Dictionary to store object queues based on their names
        private readonly Dictionary<string, Queue<GameObject>> _objectPool = new();
        
        public GameObject GetObject(GameObject requestGameObject)
        {
            if (!_objectPool.TryGetValue(requestGameObject.name, out Queue<GameObject> objectList))
                return CreateNewObject(requestGameObject);
            if (objectList.Count == 0)
                return CreateNewObject(requestGameObject);
            
            var activeObject = objectList.Dequeue();
            activeObject.SetActive(true);
            return activeObject;

        }

        // Method to create a new object and add it to the pool
        private static GameObject CreateNewObject(GameObject gameObject)
        {
            var newGameObject = Instantiate(gameObject);
            newGameObject.name = gameObject.name;
            return newGameObject;
        }

        // Method to return an object to the pool
        public void ReturnGameObject(GameObject requestGameObject)
        {
            if (_objectPool.TryGetValue(requestGameObject.name, out var objectList))
                objectList.Enqueue(requestGameObject);
            else
            {
                // If the pool doesn't contain objects of the specified type, create a new queue
                var newObjectQueue = new Queue<GameObject>();
                newObjectQueue.Enqueue(requestGameObject);
                _objectPool.Add(requestGameObject.name, newObjectQueue);
            }

            // Deactivate the returned object
            requestGameObject.SetActive(false);
        }
    }
}
