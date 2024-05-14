using UnityEngine;
using UnityEngine.InputSystem;

public class WorldControl : MonoBehaviour
{
    public InputActionReference ourThumbAction = null;
    public Vector2 thumbAxis;
    public bool shrinkModeActivated = false;
    [SerializeField] float actionThreshold = 0.8f;
    [SerializeField] private GameObject rotationObject;
    [SerializeField] private GameObject scaleObject;
    [SerializeField] private float rotateDegressPerSecond = 0.5f;
    [SerializeField] private float scaleSpeed = 0.5f;
    [SerializeField] private Transform newLocation;
    [SerializeField] private Transform zoomLocation;
    [SerializeField] private Transform viewer;
    
    private float t = 0f;
    private float maxScale = 1.0f;
    private float minScale = 0.2f;

    private void Awake()
    {
        ourThumbAction.action.performed += XAction;
    }
    private void OnEnable()
    {
        ourThumbAction.action.Enable();
    }
    private void OnDisable()
    {
        ourThumbAction.action.Disable();
    }

    private void XAction(InputAction.CallbackContext context)
    {
        if (shrinkModeActivated == false)
        {
            return;
        }
        thumbAxis = context.ReadValue<Vector2>();
        // Debug.Log(thumbAxis);
        if (thumbAxis.x > actionThreshold)
        {
            rotate(1);
        }
        else if (thumbAxis.x < -actionThreshold)
        {
            rotate(-1);
        }
        if (thumbAxis.y > actionThreshold)
        {
            scale(1);
        }
        else if (thumbAxis.y < -actionThreshold)
        {
            scale(-1);
        }
    }

    private void rotate(int multiplier)
    {
        Debug.Log("ROTATING");
        rotationObject.transform.Rotate(new Vector3(0, rotateDegressPerSecond * multiplier, 0) * Time.deltaTime) ;
    }

    private void scale(int multiplier)
    {
        t = t + (-multiplier * scaleSpeed * Time.deltaTime);
        if (t >= 1.0f) return;
        if (t <= 0) return;
        Debug.Log("T=" + t);
        float worldScale = Mathf.Lerp(maxScale, minScale, t);
        scaleObject.transform.localScale = new Vector3(worldScale, worldScale, worldScale);
        Vector3 position = Vector3.Lerp(newLocation.transform.position, zoomLocation.transform.position, t);
        viewer.transform.localPosition = position;
    }

    private void oldScale(int multiplier)
    {
        float scale = scaleObject.transform.localScale.x;
        float newScale = scale + (multiplier * scaleSpeed * Time.deltaTime);
        scaleObject.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
