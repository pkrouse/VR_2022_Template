using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private PopoutHandler target;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Activating target in a bit.");
        StartCoroutine(ActivateTarget());
    }

    private IEnumerator ActivateTarget()
    {
        yield return new WaitForSeconds(3f);
        target.Activate();
    }
}
