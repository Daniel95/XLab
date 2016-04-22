using UnityEngine;
using System.Collections;

public class RandomDirectionPush : RandomizedCooldown {

    [SerializeField]
    private float pushStrength = 1f;

    [SerializeField]
    private float pushStrengthRandomizer = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void Execute()
    {
        base.Execute();

        float randomStrength = Random.Range(-pushStrengthRandomizer, pushStrengthRandomizer);

        float totalStrength = pushStrength + randomStrength;

        rb.AddForce(new Vector2(Random.Range(-totalStrength, totalStrength), Random.Range(-totalStrength, totalStrength)));
    }
}
