using UnityEngine;
using TMPro;
using System.Collections;

public class LocationController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] string _locationName;
    [SerializeField] string _locationGuideText;
    [SerializeField] string _locationMusicType;
    [SerializeField] bool _isProject;
    [SerializeField] float _projectTime;
    [SerializeField] string _adjacentRequirementName;

    private bool _canPlace;

    private TextMeshPro _labelText;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        MusicController musicController = GameObject.FindObjectOfType<MusicController>();
        musicController.IncreaseTrack(_locationMusicType);

        if (_adjacentRequirementName == "")
        {
            _canPlace = true;
        }

        if (_isProject)
        {
            _labelText = GetComponentInChildren<TextMeshPro>();
            _labelText.gameObject.SetActive(false);
            _labelText.text = "In construction";
            StartCoroutine("ProjectBuild");
        }
        else
        {
            _labelText = GetComponentInChildren<TextMeshPro>();
            _labelText.gameObject.SetActive(false);
            _labelText.text = _locationName;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LocationController>() != null)
        {
            if (collision.GetComponent<LocationController>().GetName() == _adjacentRequirementName)
            {
                _canPlace = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_adjacentRequirementName != "")
        {
            _canPlace = false;
        }
    }

    private void OnMouseOver()
    {
        _labelText.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        _labelText.gameObject.SetActive(false);
    }

    public string GetName()
    {
        return _locationName;
    }

    public string GetGuide()
    {
        return _locationGuideText;
    }

    public float GetTime()
    {
        return _projectTime;
    }

    public bool CanPlace()
    {
        return _canPlace;
    }


    public bool GetProjectStatus()
    {
        return _isProject;
    }

    IEnumerator ProjectBuild()
    {
        while (_gameManager._softPause)
        {
            yield return null;
        }
        yield return new WaitForSeconds(_projectTime);
        while (_gameManager._softPause)
        {
            yield return null;
        }
        _labelText.gameObject.SetActive(false);
        _labelText.text = _locationName;
    }
}
