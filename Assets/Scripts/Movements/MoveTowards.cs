using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.01f;

    private float totalSpeed;

    [SerializeField]
    private float rotateSpeed = 0.1f;

    //the current target we are moving towards
    private Vector2 currentTarget;

    private Quaternion targetRotation;

    void Start()
    {
        //the difference in vector to the target
        Vector2 vectorToTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);

        //calculate the angle to our target
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(angle, 90, 90);
    }

    void FixedUpdate()
    {
        //the difference in vector to the target
        Vector2 vectorToTarget = currentTarget - new Vector2(transform.position.x, transform.position.y);

        //calculate the angle to our target
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

        //use the angle to get the rotation to our target
        //targetRotation = Quaternion.AngleAxis(angle, Vector3);
        targetRotation = Quaternion.Euler(angle, 90, 90);

        //move to the targetrotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed);
    }

    // van buitenaf kun je de huidige target uitlezen
    public Vector2 Target
    {
        get { return currentTarget; }
        set { currentTarget = value; }
    }
}
