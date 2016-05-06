using UnityEngine;
using System.Collections;

public class IgnoreNonParentCollision : MonoBehaviour
{
    private Collider myCollider;

    private Transform myParent;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myParent = transform.parent;
    }

    void OnCollisionEnter(Collision _collision)
    {
        //check if our collision is from our parent, if not, ignore the collision
        if (_collision.transform != transform.parent)
        {
            Physics.IgnoreCollision(myCollider, _collision.collider);
        }
    }
}