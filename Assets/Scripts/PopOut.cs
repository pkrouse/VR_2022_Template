using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOut : MonoBehaviour
{
    [SerializeField] private GameObject label;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pop out dialog here.");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Retract dialog here.");
    }
}
