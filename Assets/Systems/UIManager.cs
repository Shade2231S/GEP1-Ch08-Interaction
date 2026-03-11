using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditorInternal;
using System.Collections;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] bool debugEnabled = false;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TMP_Text promptText;
    //[SerializeField] private string prompt = "(Space) to Interact";
    [SerializeField] private float messageduration = 3.0f;
    [SerializeField] private float fadeouttime = 0.5f;
    private string currentmessage;
    private Coroutine fadecoroutine;
    private void Start()
    {
        
    }
    public void HidePrompt(string prompt)
    {
        promptText.text = prompt;
        Debug.Log("played hide");
    }
    public void DisplayPrompt(string prompt)
    {
        promptText.text = prompt;
        Debug.Log("played display");
    }
    public void DesplayMessage(string message)
    {
        messageText.text = message;
        if (fadecoroutine != null)
        {
            StopCoroutine(fadecoroutine);
        }
        fadecoroutine = StartCoroutine(DisplayinOutText(message));
    }
    private IEnumerator DisplayinOutText(string message)
    {
        //messagetext.text = currentmessage;
        messageText.alpha = 1;
        float elapsedtime = 0f;
        Color orignalcolor = messageText.color;
        while (elapsedtime < messageduration)
        {
            elapsedtime += Time.deltaTime;
            float Alpha = Mathf.Lerp(1f,0f,elapsedtime / fadeouttime);
            yield return null;
        } 
        yield return new WaitForSeconds(messageduration);
        messageText.text = "";
    }
}