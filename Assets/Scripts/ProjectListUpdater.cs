using UnityEngine;
using System.Collections.Generic;

public class ProjectListUpdater : MonoBehaviour
{
    [Header("Project List")]
    [SerializeField] GameObject _farmProject;
    [SerializeField] GameObject _mineProject;
    [SerializeField] GameObject _marketplaceProject;

    private void Awake()
    {
        _farmProject.SetActive(false);
        _mineProject.SetActive(false);
        _marketplaceProject.SetActive(false);
    }

    public void UpdateProjectList(List<LocationController> locations)
    {
        bool hasVillage = false;
        bool hasResidentialDistrict = false;

        foreach(LocationController location in locations)
        {
            if (location.GetName() == "Village")
            {
                hasVillage = true;
            }
            else if (location.GetName() == "Residential District")
            {
                hasResidentialDistrict = true;
            }
        }

        if (hasVillage)
        {
            _farmProject.SetActive(true);
            _mineProject.SetActive(true);
        }
        else
        {
            _farmProject.SetActive(false);
            _mineProject.SetActive(false);
        }

        if (hasResidentialDistrict)
        {
            _marketplaceProject.SetActive(true);
        }
        else
        {
            _marketplaceProject.SetActive(false);
        }
    }
}
