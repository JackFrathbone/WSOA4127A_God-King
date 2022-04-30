using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChooseLocations : Event
{
    public GameObject locationPrefab1;
    public GameObject locationPrefab2;

    public override void OnRunDefault()
    {
        return;
    }

    public override void OnRunOption1()
    {
        LocationPlacementController locationPlacementController = GameObject.FindObjectOfType<LocationPlacementController>();
        locationPlacementController.SetNewLocation(locationPrefab1);

    }

    public override void OnRunOption2()
    {
        LocationPlacementController locationPlacementController = GameObject.FindObjectOfType<LocationPlacementController>();
        locationPlacementController.SetNewLocation(locationPrefab2);
    }
}
