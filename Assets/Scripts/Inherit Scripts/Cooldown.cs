using UnityEngine;
using System.Collections;

public class Cooldown : MonoBehaviour {

    [SerializeField]
    protected float cooldown = 1;

    virtual protected void Awake()
    {
        InvokeRepeating("Execute", 0, cooldown);
    }

    virtual protected void Execute()
    {

    }
}
