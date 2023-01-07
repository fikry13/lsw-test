using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : ItemDispenser {

    private bool taken;
    [SerializeField]
    private string infoText;

    public override void Interact()
    {
        if (!taken)
        {
            DialogManager.Instance.DisplaySystemMessage(infoText, () => {
                base.Interact();
                DialogManager.Instance.HideDialog();
                taken = true;
            });
        }
    }
}
