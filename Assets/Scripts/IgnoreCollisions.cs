using UnityEngine;
using System.Collections.Generic;

public class IgnoreCollisions : MonoBehaviour
{
    //collision to not ignore
    private List<Transform> activeCollisions = new List<Transform>();

    private Collider myCollider;

    // Use this for initialization
    void Awake()
    {
        myCollider = GetComponent<Collider>();
        activeCollisions.Add(transform.parent);
    }

    void OnCollisionEnter(Collision _collision)
    {
        for (int i = 0; i < activeCollisions.Count; i++) {
            if (_collision.transform != activeCollisions[i]) {
                Physics.IgnoreCollision(myCollider, _collision.collider);
            }
        }
    }

    public void AddActiveCollision(Transform _transformToUnignore) {
        activeCollisions.Add(_transformToUnignore);
    }

    public void RemoveActiveCollision(Transform _transformToignore)
    {
        activeCollisions.Remove(_transformToignore);
    }

    public void ReactivateCollision(Collider _collisionToUnignore)
    {
        Physics.IgnoreCollision(myCollider, _collisionToUnignore, false);
    }
}