using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocationPlacementController : MonoBehaviour
{
    [Header("References")]
    //image of the currently selected location to display
    [SerializeField] float _placementMoveSpeed;
    [SerializeField] Image _currentLocationImage;
    [SerializeField] GameObject _locationUI;
    [SerializeField] TextMeshProUGUI _locationName;
    [SerializeField] GameObject _tutorialUI;
    [SerializeField] TextMeshProUGUI _tutorialText;

    private GameObject _currentLocationPrefab;
    private Camera _cam;
    private Vector2 _mousePos;

    private void Start()
    {
        _cam = Camera.main;
        _locationUI.SetActive(false);
        _tutorialUI.SetActive(false);
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
        _currentLocationPrefab = Instantiate(newlocationPrefab, Vector2.zero, Quaternion.identity);
        _currentLocationImage.sprite = _currentLocationPrefab.GetComponent<SpriteRenderer>().sprite;

        _locationName.text = _currentLocationPrefab.GetComponent<LocationController>().GetName();
        _tutorialText.text = _currentLocationPrefab.GetComponent<LocationController>().GetGuide();

        _locationUI.SetActive(true);
        _tutorialUI.SetActive(true);
    }

    private void PlaceLocation()
    {
        Vector2 spawnPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        _currentLocationPrefab.transform.position = spawnPosition;
        _currentLocationPrefab = null;
        _locationUI.SetActive(false);
        _tutorialUI.SetActive(false);
    }
}
