using UnityEngine;
using UnityEngine.InputSystem;

public class PointerController : MonoBehaviour
{
    public InputActionReference pointerFire;
    private LineRenderer laserLine;
    private float lineWidth = 0.01f;
    [SerializeField] private Transform aimer;
    RaycastHit hit;
    int debugCount = 0;
    bool onClickable = false;
    private Vector3 endPoint;
    private GameObject hitTarget;
    [SerializeField] private Material neutralMaterial;
    [SerializeField] private Material clickableMaterial;
    [SerializeField] private Material readableMaterial;
    [SerializeField] private GameObject triggerObject;
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.positionCount = 2;
        laserLine.startWidth = lineWidth;
        laserLine.endWidth = lineWidth;
        laserLine.enabled = true;
        laserLine.material = neutralMaterial;
        pointerFire.action.performed += Travel;
    }

    void Update()
    {
        laserLine.SetPosition(0, aimer.position);
        Vector3 end = (aimer.forward * 8) + aimer.position;
        laserLine.SetPosition(1, end);

        if (Physics.Raycast(aimer.position, aimer.forward, out hit))
        {
            endPoint = hit.point;
            hitTarget = hit.transform.gameObject;
            triggerObject.transform.position = end;
            laserLine.SetPosition(0, aimer.position);
            laserLine.SetPosition(1, endPoint);
            if (hit.collider.CompareTag("Readable").Equals(true))
            {
                Debug.Log("Readable");
                onClickable = false;
                laserLine.material = readableMaterial;
            }
            else if (hit.collider.CompareTag("Clickable").Equals(true))
            {
                onClickable = true;
                laserLine.material = clickableMaterial;
            }
            else
            {
                onClickable = false;
                laserLine.material = neutralMaterial;
            }
        }
        else
        {
            laserLine.material = neutralMaterial;
        }
    }
    private void Travel(InputAction.CallbackContext obj)
    {
        if (onClickable == false)
        {
            return;
        }
        hitTarget.GetComponent<ActionStarter>().StartAction(ActionStarter.Action.SHRINK_WORLD);
    }
}
