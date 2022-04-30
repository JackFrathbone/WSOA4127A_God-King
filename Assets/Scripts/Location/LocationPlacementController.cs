using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class LocationPlacementController : MonoBehaviour
{
    [Header("Location List")]
    public List<LocationController> locationsPlaced = new List<LocationController>();

    [Header("References")]
    //image of the currently selected location to display
    [SerializeField] float _placementMoveSpeed;
    [SerializeField] Image _currentLocationImage;
    [SerializeField] GameObject _locationUI;
    [SerializeField] TextMeshProUGUI _locationName;
    [SerializeField] GameObject _tutorialUI;
    [SerializeField] TextMeshProUGUI _tutorialText;
    //For the project menu
    [SerializeField] GameObject _projectUI;

    [SerializeField] ProjectListUpdater _projectListUpdater;

    private bool _firstPlacement;
    private bool _projectIsRunning;

    private LocationController _currentLocationPrefab;
    private Camera _cam;
    private Vector2 _mousePos;

    private GameManager _gameManager;
   

    private void Start()
    {
        _cam = Camera.main;
        _locationUI.SetActive(false);
        _tutorialUI.SetActive(false);

        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (_currentLocationPrefab != null)
        {
            _mousePos = Input.mousePosition;
            _mousePos = _cam.ScreenToWorldPoint(_mousePos);

            _currentLocationPrefab.transform.position = Vector2.Lerp(transform.position, _mousePos, _placementMoveSpeed);

            if (Input.GetMouseButtonDown(1))
            {
                PlaceLocation();
            }
        }
    }

    public void SetNewLocation(GameObject newlocationPrefab)
    {
        _currentLocationPrefab = Instantiate(newlocationPrefab, Vector2.zero, Quaternion.identity).GetComponent<LocationController>();
        _currentLocationImage.sprite = _currentLocationPrefab.GetComponent<SpriteRenderer>().sprite;

        _locationName.text = _currentLocationPrefab.GetName();
        _tutorialText.text = _currentLocationPrefab.GetGuide();

        _locationUI.SetActive(true);
        _tutorialUI.SetActive(true);

        if (_currentLocationPrefab.GetProjectStatus() && !_projectIsRunning)
        {
            StartCoroutine(ProjectBuild(_currentLocationPrefab.GetTime()));
        }

        _gameManager.SoftPause();
    }

    private void NewProject()
    {
        _gameManager.Pause();
        _projectUI.SetActive(true);
    }
    private void PlaceLocation()
    {
        if (!_currentLocationPrefab.CanPlace())
        {
            return;
        }

        Vector2 spawnPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        _currentLocationPrefab.transform.position = spawnPosition;
        locationsPlaced.Add(_currentLocationPrefab);
        _projectListUpdater.UpdateProjectList(locationsPlaced);

        _currentLocationPrefab = null;
        _locationUI.SetActive(false);
        _tutorialUI.SetActive(false);

        _gameManager.UnPause();

        if (!_firstPlacement)
        {
            NewProject();
            _firstPlacement = true;
        }
    }

    IEnumerator ProjectBuild(float projectTime)
    {
        while (_gameManager._softPause)
        {
            yield return null;
        }
        _projectIsRunning = true;
        yield return new WaitForSeconds(projectTime);
        while (_gameManager._softPause)
        {
            yield return null;
        }
        _projectIsRunning = false;
        NewProject();
    }
}
