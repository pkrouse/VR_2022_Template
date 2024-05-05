using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;
    private XRPokeInteractor _xrPokeInteractor;
    void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokeToAttachPoint();
    }

    private void SetPokeToAttachPoint()
    {
        if (PokeAttachPoint is null || _xrPokeInteractor is null)
        {
            Debug.LogError("You need to set things up correctly.");
        }
        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }
}
