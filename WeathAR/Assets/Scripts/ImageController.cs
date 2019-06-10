using UnityEngine;
using Vuforia;

public class ImageController : MonoBehaviour, ITrackableEventHandler
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        Debug.Log("HALLO");
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            Debug.Log("TRACKED " );
        }
        else if (newStatus == TrackableBehaviour.Status.DETECTED)
        {
            Debug.Log("DETECTED " );
        }
    }
}