using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI speakerName;
    public Image portriat;

    [Header("Data")]
    public DialogDatabaseSO dialogDatabase;
    private Dictionary<int, DialogLineSO> dialogDictionary;
    public float typingSpeed = 0.02f;

    [Header("Input")]
    public InputAction continueDialog;
    private bool inputRecieved; 

    public UnityEvent OnMessageComplete;

    private void Awake()
    {
        continueDialog.Enable();

        continueDialog.performed += ContinueDialog;

    }

    private void Start()
    {
        dialogDatabase.Initialize();
        dialogDictionary = dialogDatabase.dialogDictionary;
        gameObject.SetActive(false);
    }

    public void ContinueDialog(InputAction.CallbackContext c)
    {
        inputRecieved = true;
    }

    public void InitiateDialog(int id)
    {
        portriat.sprite = dialogDictionary[id].speakerPortrait;
        speakerName.text = dialogDictionary[id].speakerName;
        StartCoroutine(DisplayMessage(id));
    }

    private IEnumerator DisplayMessage(int id)
    {
        dialogText.text = "";

        string currentMessage = dialogDictionary[id].dialogLine;

        for(int i = 0; i < currentMessage.Length; i++)
        {
            dialogText.text += currentMessage[i];
            dialogText.ForceMeshUpdate();
            yield return new WaitForSeconds(typingSpeed);
        }

        inputRecieved = false;
        yield return new WaitUntil(() => inputRecieved);
        OnMessageComplete?.Invoke();
    }
}
