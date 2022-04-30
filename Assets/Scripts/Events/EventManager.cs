using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] EventUIController _eventUIController;

    [SerializeField] List<Event> _events = new List<Event>();
    private int _onEvent;

    private void Start()
    {
        _onEvent = 0;
        _eventUIController.SetEmergency(_events[0]);
        _onEvent++;
    }

    public void CallNextEvent()
    {
        if(_onEvent >= _events.Count)
        {
            return;
        }

        if (_events[_onEvent].isAction)
        {
            _eventUIController.SetAction(_events[_onEvent]);
        }
        else
        {
            _eventUIController.SetEmergency(_events[_onEvent]);
        }

        _onEvent++;
    }
}