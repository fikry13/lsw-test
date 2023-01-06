using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private DialogDisplay dialogDisplay;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void HideDialog()
    {
        dialogDisplay.gameObject.SetActive(false);
        GameManager.Instance.SetPlayerInput(true);
    }

    public void DisplayDialog(Dialog dialog, Action onDialogEnd = null)
    {
        GameManager.Instance.SetPlayerInput(false);
        dialogDisplay.gameObject.SetActive(true);   
        dialogDisplay.DisplayDialog(dialog, onDialogEnd);
    }

    public void DisplaySystemMessage(string message, Action onDialogEnd = null)
    {
        Dialog dialog = new Dialog();
        dialog.speaker = "";
        dialog.dialog = message;
        DisplayDialog(dialog, onDialogEnd);
    }
}
