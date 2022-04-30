using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    public int secondsPerMonth;
    public int month;
    public int year;

    [Header("References")]
    [SerializeField] EventManager _eventManager;
    [SerializeField] CameraController _cameraController;
    [SerializeField] TextMeshProUGUI _yearText;
    [SerializeField] TextMeshProUGUI _monthText;

    private float _time;
    private float _eventTime;

    private float _randomEventTimer;

    [Header("Public Variables")]
    public bool _softPause;

    private void Start()
    {
        _randomEventTimer = ResetRandomTimer();
    }

    private void Update()
    {
        if (_softPause)
        {
            return;
        }

        _time += 1 * Time.deltaTime;
        _eventTime += 1 * Time.deltaTime;

        if (_time >= secondsPerMonth)
        {
            _time = 0;
            month++;
            if(month >= 12)
            {
                year++;
                month = 0;
            }
        }

        if(_eventTime >= _randomEventTimer)
        {
            _eventTime = 0;
            _eventManager.CallNextEvent();
            _randomEventTimer = ResetRandomTimer();
        }

        _yearText.text = "Year: " + year.ToString();
        _monthText.text = "Month: " + month.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private float ResetRandomTimer()
    {
        return Random.Range(10f, 15f);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _cameraController.isPaused = true;
    }

    public void SoftPause()
    {
        Time.timeScale = 1;
        _cameraController.isPaused = false;
        _softPause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        _cameraController.isPaused = false;
        _softPause = false;
    }
}