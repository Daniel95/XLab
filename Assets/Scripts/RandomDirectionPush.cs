using UnityEngine;
using System.Collections;

public class RandomDirectionPush : RandomizedCooldown {

    [SerializeField]
    private float pushStrength = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void Execute()
    {
        base.Execute();
        rb.AddForce(new Vector2(Random.Range(-pushStrength,pushStrength), Random.Range(-pushStrength, pushStrength)));
    }
}
