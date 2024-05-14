using UnityEngine;
public class ExperienceManager : Singleton<ExperienceManager>
{
    private ShrinkWorld shrinkWorld;
    private WorldControl worldControl;
    private void Start()
    {
        shrinkWorld = GetComponentInChildren<ShrinkWorld>();
        if (shrinkWorld is not null)
        {
            Debug.Log("ExperinceManager is working properly.");
        }
        worldControl = GetComponentInChildren<WorldControl>();
    }
    public void ShrinkWorldExperience()
    {
        shrinkWorld.Activate();
        worldControl.shrinkModeActivated = true;
    }
}
