using UnityEngine;

public class Pickup_Interaction : MonoBehaviour, InteractInterface
{
    public bool debugEnabled = false;
    public void Interact()
    { 
        if (debugEnabled) Debug.Log("Interact with " + gameObject.name);
        Destroy(gameObject);
    }
    public void Focused()
    {
    }
    public void UnFocused()
    {
    }
}
