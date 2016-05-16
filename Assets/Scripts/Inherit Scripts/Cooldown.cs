using UnityEngine;
using System.Collections;

public class Cooldown : MonoBehaviour {

    [SerializeField]
    protected float cooldown = 1;

    private bool executing = true;

    virtual protected void Awake()
    {
        InvokeRepeating("CheckExecuting", 0, cooldown);
    }

    private void CheckExecuting() {
        if(executing)
            Execute();
    }

    virtual protected void Execute()
    {

    }

    public bool Executing {
        set { executing = value; }
    }
}
