using System.Collections.Generic;
using UnityEngine;

public class ComponentsDisabler : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> componentsToDisable;

    public void DisableComponents()
    {
        foreach (var component in componentsToDisable)
        {
            component.enabled = false;
        }
    }
}
