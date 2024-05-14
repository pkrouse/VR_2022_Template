using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStarter : MonoBehaviour
{
    public enum Action
    {
        SHRINK_WORLD
    }
    public void StartAction(Action action)
    {
        if (action == Action.SHRINK_WORLD)
        {
            ExperienceManager.Instance.ShrinkWorldExperience();
        }
    }
}
