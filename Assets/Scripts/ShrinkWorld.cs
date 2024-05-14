using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ShrinkWorld : MonoBehaviour
{
    [SerializeField] private GameObject[] hideables;
    [SerializeField] private GameObject[] earlyRevealbles;
    [SerializeField] private GameObject[] revealbles;
    [SerializeField] private float shrinkScale;
    [SerializeField] private float moveTimeInSeconds = 3f;
    [SerializeField] private GameObject highGroundPlane;
    [SerializeField] private GameObject newLocation;
    [SerializeField] private GameObject Player;
    // [SerializeField] private GameObject newFocusPoint;
    private bool Activated = false;

    public void Activate()
    {
        Activated = true;
        StartCoroutine(LerpPosition());
        // we will end up looking at this new focus point (right above christmas tree)
        // Vector3 direction = newFocusPoint.transform.position - newLocation.transform.position;
        // try just looking forward from new location
        Vector3 direction = newLocation.transform.forward; 
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        StartCoroutine(LerpRotation(targetRotation));
        // StartCoroutine(LerpRotation(newLocation.transform.rotation));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LerpPosition()
    {
        HideObjects();
        RevealObjects(earlyRevealbles);
        Vector3 startPosition = Player.transform.position;
        float timeElapsed = 0;
        while (timeElapsed < moveTimeInSeconds)
        {
            Player.transform.position = Vector3.Lerp(startPosition, newLocation.transform.position, timeElapsed / moveTimeInSeconds);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Player.transform.position = newLocation.transform.position;
        RevealObjects(revealbles);
    }

    private IEnumerator LerpRotation(Quaternion endRotation)
    {
        float timeElapsed = 0;

        Quaternion startRotation = Player.transform.rotation;
        while (timeElapsed < moveTimeInSeconds) { 
            Player.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / moveTimeInSeconds);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Player.transform.rotation = endRotation;
    }

    private void HideObjects()
    {
        foreach (GameObject go in hideables)
        {
            go.SetActive(false);
        }
    }

    private void RevealObjects(GameObject[] targets)
    {
        foreach (GameObject go in targets)
        {
            go.SetActive(true);
        }
    }
}
