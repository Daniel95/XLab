using UnityEngine;
using System.Collections;

public class ControlledBounce : MonoBehaviour {

    [SerializeField]
    private Transform circle;

    [SerializeField]
    private float gravityStrength = 1;

    [SerializeField]
    private float minDistance = 0.01f;

    [SerializeField]
    private float time = 10;

    private float startTime;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter() {
        StartCoroutine(ApplyGravity());

    }

    IEnumerator ApplyGravity()
    {
        time = startTime;

        while (Vector2.Distance(transform.position, circle.transform.position) > minDistance || time > 0)
        {
            time--;

            Vector2 vectorToTarget = new Vector2(circle.position.x, circle.position.y) - new Vector2(transform.position.x, transform.position.y);

            //calculate the angle to our target
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

            rb.velocity = (vectorToTarget * Mathf.Abs(angle)) * gravityStrength;
            
            yield return new WaitForFixedUpdate();
        }
    }
}
