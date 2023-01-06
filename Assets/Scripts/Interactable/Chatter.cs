using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatter : Interactable
{
    [SerializeField]
    private Dialog[] _dialog;

    private int dialogIndex = -1;
    
    public override void Interact()
    {
        base.Interact();
        Debug.LogWarning("HAHA");

        DisplayDialog();
    }

    public void DisplayDialog(Action onDialogDone = null)
    {
        DialogManager.Instance.DisplayDialog(GetNextDialog(), () => {
            if(dialogIndex < _dialog.Length - 1)
            {
                DisplayDialog();
            }
            else
            {
                dialogIndex = -1;
                DialogManager.Instance.HideDialog();
                Debug.Log(onDialogDone == null);
                onDialogDone?.Invoke();
            }
        });
    }
    
    Dialog GetNextDialog()
    {
        if (dialogIndex < _dialog.Length - 1)
        {
            dialogIndex++;
        }
        return _dialog[dialogIndex];
    }
}
