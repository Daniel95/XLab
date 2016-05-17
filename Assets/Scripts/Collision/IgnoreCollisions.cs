using UnityEngine;
using System.Collections.Generic;

public class IgnoreCollisions : MonoBehaviour
{
    //collision to not ignore
    private List<Collider> activeCollisions = new List<Collider>();

    private Collider myCollider;

    // Use this for initialization
    void Awake()
    {
        myCollider = GetComponent<Collider>();
        //activeCollisions.Add(transform.parent.GetComponent<MeshCollider>());

        Collider[] parentsBoxColliders = transform.parent.GetComponents<Collider>();

        for (int i = 0; i < parentsBoxColliders.Length; i ++) {
            activeCollisions.Add(parentsBoxColliders[i]);
        }
    }

    void OnCollisionEnter(Collision _collision)
    {
        bool ignoreCollision = true;

        for (int i = 0; i < activeCollisions.Count; i++)
        {
            //print("Looking for: " + _collision.gameObject.name + ", in our active List: " + activeCollisions[i].gameObject.name);
            if (_collision.collider == activeCollisions[i])
            {
                ignoreCollision = false;
                //print("reacting: " + _collision.collider);
            }
        }
        if (ignoreCollision)
        {
            Physics.IgnoreCollision(myCollider, _collision.collider);
            ///print("ignored: " + _collision.collider);
        }
    }

    public void AddActiveCollision(Collider _colliderToReactTo) {
        //print("WE ARE ADDING: " + _colliderToReactTo);
        activeCollisions.Add(_colliderToReactTo);
    }

    public void RemoveActiveCollision(Collider _colliderToignore)
    {
        activeCollisions.Remove(_colliderToignore);
    }

    public void ReactivateCollision(Collider _collisionToUnignore)
    {
        Physics.IgnoreCollision(myCollider, _collisionToUnignore, false);
    }
}