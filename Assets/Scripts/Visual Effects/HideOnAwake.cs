using UnityEngine;

public class HideOnAwake : MonoBehaviour
{
    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
