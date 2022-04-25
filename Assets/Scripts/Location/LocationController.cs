using UnityEngine;
using TMPro;

public class LocationController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] string _locationName;
    [SerializeField] string _locationGuideText;

    private TextMeshPro _labelText;

    private void Awake()
    {
        _labelText = GetComponentInChildren<TextMeshPro>();
        _labelText.gameObject.SetActive(false);
        _labelText.text = _locationName;
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
}
