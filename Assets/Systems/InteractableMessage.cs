using UnityEngine;
using TMPro;
public class InteractableMessage : MonoBehaviour, InteractInterface
{
    [SerializeField] private UIManager uimanager ;
    [SerializeField] private string message = "hiii";
    private InteractInterface target;
    public bool debugEnabled = false;
    private void Awake()
    {
        uimanager = ServiceHub.Instance.UIManager;
        if (uimanager != null) Debug.Log("UImanager not found");
    }
    public void Interact()
    {
        uimanager.DesplayMessage(message);
    }
    public void Focused()
    {
    }
    public void UnFocused()
    {
    }
}
