using UnityEngine;

public class EmergencyAddLocation : Event
{
    public GameObject locationPrefab;

    public override void OnRunDefault()
    {
        if(locationPrefab != null)
        {
            LocationPlacementController locationPlacementController = GameObject.FindObjectOfType<LocationPlacementController>();
            locationPlacementController.SetNewLocation(locationPrefab);
        }
    }
}
