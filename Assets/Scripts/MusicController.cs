using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource _baseTrack;
    [SerializeField] AudioSource _warTrack;
    [SerializeField] AudioSource _AgricultureTrack;
    [SerializeField] AudioSource _industryTrack;
    [SerializeField] AudioSource _religionTrack;

    public void IncreaseTrack(string trackType)
    {
        switch (trackType)
        {
            case "war":
                _warTrack.volume += 0.25f;
                break;
            case "agriculture":
                _AgricultureTrack.volume += 0.25f;
                break;
            case "industry":
                _industryTrack.volume += 0.25f;
                break;
            case "religion":
                _religionTrack.volume += 0.25f;
                break;
            case "":
                _baseTrack.volume += 0.25f;
                break;
        }

        Mathf.Clamp(_warTrack.volume, 0f, 0.50f);
        Mathf.Clamp(_AgricultureTrack.volume, 0f, 0.50f);
        Mathf.Clamp(_industryTrack.volume, 0f, 0.50f);
        Mathf.Clamp(_religionTrack.volume, 0f, 0.50f);
    }
}
