using UnityEngine;
using System.Collections;

public class IgnoreNonParentCollision : MonoBehaviour
{
    private Collider myCollider;

    // Use this for initialization
    void Awake()
    {
        myCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision _collision)
    {
        //check if our collision is from our parent, if not, ignore the collision
        if (_collision.transform != transform.parent)
            Physics.IgnoreCollision(myCollider, _collision.collider);
    }

    public void SetKinematic(bool _isKinematic) {
        GetComponent<Rigidbody>().isKinematic = _isKinematic;
    }
}