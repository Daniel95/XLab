using UnityEngine;
using System.Collections;

public class ControlledBounce : MonoBehaviour {

    [SerializeField]
    private Transform circle;

    [SerializeField]
    private float gravityStrength = 0.0035f;

    [SerializeField]
    private float minDistance = 0.05f;

    [SerializeField]
    private float time = 30;

    private float startTime;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startTime = time;
    }

    void OnCollisionEnter(Collision collision) {
        StartCoroutine(ApplyGravity());
    }

    IEnumerator ApplyGravity()
    {
        time = startTime;

        while (Vector2.Distance(transform.position, circle.transform.position) > minDistance && time > 0)
        {
            time--;

            //the difference to the target
            Vector2 vectorToTarget = new Vector2(circle.position.x, circle.position.y) - new Vector2(transform.position.x, transform.position.y);

            //calculate the angle to our target
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

            rb.velocity = (vectorToTarget * Mathf.Abs(angle)) * gravityStrength;
            
            yield return new WaitForFixedUpdate();
        }
    }
}
