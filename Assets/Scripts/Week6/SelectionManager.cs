using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    IRayCastProvider iRayProvider;
    ISelector iSelector;
    ISelectionMode iSelectMode;

    private Transform CurrentSelection;

    private void Awake()
    {
        iRayProvider = GetComponent<IRayCastProvider>();
        iSelector = GetComponent<ISelector>();
        iSelectMode = GetComponent<ISelectionMode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSelection != null)
            iSelectMode.OnDeselect(CurrentSelection);
        iSelector.Check(iRayProvider.CreateRay());
        CurrentSelection = iSelector.GetSelection();

        if (CurrentSelection != null)
            iSelectMode.OnSelect(CurrentSelection);
    }
}
