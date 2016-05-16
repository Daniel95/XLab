using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

    //delegate type
    public delegate void ShrinkMethod();

    //delegate instance
    public ShrinkMethod FinishedShrinking;

    [SerializeField]
    private float time = 1;

    private Vector3 velocity;

    public void StartShrinking(float _newSize) {
        StartCoroutine(Shrinking(_newSize));
    }

    IEnumerator Shrinking(float _size)
    {
        while (transform.localScale.y > _size * 1.1f) {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(_size, _size, _size), ref velocity, time);
            yield return new WaitForFixedUpdate();
        }

        if (FinishedShrinking != null)
            FinishedShrinking();
    }
}
