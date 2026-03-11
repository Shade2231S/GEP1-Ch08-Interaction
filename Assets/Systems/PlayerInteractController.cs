using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractController : MonoBehaviour
{
    public bool debugEnabled = false;
    private InteractInterface target;
    [SerializeField] private GameObject debugCI;
    [SerializeField] private float messageduration = 3.0f;
    [SerializeField] private UIManager uimanager;
    [SerializeField] private string promptOn = "(Space) to Interact";
    [SerializeField] private string promptOff = "";

    private void Start()
    {
        uimanager = ServiceHub.Instance.UIManager;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.TryGetComponent(out InteractInterface foundInteractable))
        {
            target = foundInteractable;
            debugCI = other.gameObject;
            uimanager.DisplayPrompt(promptOn);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out InteractInterface foundInteractable))
        {
            target = null;
            debugCI = null;
            uimanager.HidePrompt(promptOff);
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        { 
            if (debugEnabled) Debug.Log("Atempten to Interact " + gameObject.name);
            if (target != null)
            {                
                target.Interact();
            }
        }
    }
}
