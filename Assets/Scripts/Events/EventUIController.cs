using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventUIController : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] GameObject _actionVisuals;
    [SerializeField] GameObject _emergencyVisuals;

    [Header("Actions")]
    [SerializeField] TextMeshProUGUI _actionTitle;
    [SerializeField] TextMeshProUGUI _actionText;
    [SerializeField] TextMeshProUGUI _actionButton1Text;
    [SerializeField] TextMeshProUGUI _actionButton2Text;
    [SerializeField] Button _actionButton1;
    [SerializeField] Button _actionButton2;
    [SerializeField] Button _ignoreButton;

    [Header("Emergencies")]
    [SerializeField] TextMeshProUGUI _emergencyTitle;
    [SerializeField] TextMeshProUGUI _emergencyText;
    [SerializeField] Button _emergencyButton;

    private GameManager _gameManager;

    public void SetAction(Event eventRun)
    {
        if (_gameManager == null)
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        _actionVisuals.SetActive(true);
        _gameManager.Pause();

        _actionButton1.onClick.RemoveAllListeners();
        _actionButton2.onClick.RemoveAllListeners();
        _ignoreButton.onClick.RemoveAllListeners();

        _actionTitle.text = eventRun.title;
        _actionText.text = eventRun.description;
        _actionButton1Text.text = eventRun.option1Description;
        _actionButton2Text.text = eventRun.option2Description;

        _actionButton1.onClick.AddListener(delegate { eventRun.OnRunOption1(); _actionVisuals.SetActive(false); });
        _actionButton2.onClick.AddListener(delegate { eventRun.OnRunOption2(); _actionVisuals.SetActive(false); });
        _ignoreButton.onClick.AddListener(delegate { eventRun.OnRunDefault(); _actionVisuals.SetActive(false); });
    }

    public void SetEmergency(Event eventRun)
    {
        if (_gameManager == null)
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        _emergencyVisuals.SetActive(true);
        _gameManager.Pause();

        _emergencyButton.onClick.RemoveAllListeners();

        _emergencyTitle.text = eventRun.title;
        _emergencyText.text = eventRun.description;
        _emergencyButton.onClick.AddListener(delegate { eventRun.OnRunDefault(); _emergencyVisuals.SetActive(false); });
    }
}
