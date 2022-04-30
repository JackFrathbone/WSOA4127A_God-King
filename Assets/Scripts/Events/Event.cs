using UnityEngine;

public class Event : MonoBehaviour
{
    [Header("General Settings")]
    public string title;
    public string description;

    [Header("Action Settings")]
    public bool isAction;
    public string option1Description;
    public string option2Description;

    //Outcome for emergency or ignore for action
    public virtual void OnRunDefault()
    {
        
    }

    public virtual void OnRunOption1()
    {

    }

    public virtual void OnRunOption2()
    {

    }
}
