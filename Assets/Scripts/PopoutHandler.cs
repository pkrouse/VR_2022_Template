using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutHandler : MonoBehaviour
{
    [SerializeField] private GameObject scaleable;
    private bool active = false;

    private float initialScale;
    // How long it takes to scale up and down.
    private float scaleTime = 0.3f;
    // How long to stay scaled up
    private float hangTime = 3f;
    void Start()
    {
        initialScale = scaleable.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        StartCoroutine(ScaleUp());
    }

    private IEnumerator ScaleUp()
    {
        active = true;
        float elapsedTime = 0f;
        float currentScale = initialScale;
        while (elapsedTime < scaleTime)
        {
            elapsedTime += Time.deltaTime;
            currentScale = Mathf.Lerp(initialScale, 1.0f, elapsedTime/scaleTime);
            scaleable.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            yield return null;
        }
        StartCoroutine(Pause());
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(hangTime);
        StartCoroutine(ScaleDown());
    }
    
    private IEnumerator ScaleDown()
    {
        float elapsedTime = 0f;
        float currentScale = initialScale;
        while (elapsedTime < scaleTime)
        {
            elapsedTime += Time.deltaTime;
            currentScale = Mathf.Lerp(1.0f, initialScale, elapsedTime/scaleTime);
            scaleable.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            yield return null;
        }
        active = false;
    }
    
    public void Deactivate()
    {
        StopAllCoroutines();
        scaleable.transform.localScale = new Vector3(initialScale, initialScale, initialScale);
        active = false;
    }
}
