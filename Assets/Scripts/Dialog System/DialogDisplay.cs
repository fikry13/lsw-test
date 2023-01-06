using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI speakerText;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private Graphic indicator;
    [SerializeField]
    private float textSpeed = 0.03f;

    private bool next;

    Tween textDisplay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textDisplay.IsPlaying())
            {
                textDisplay.Complete();
            }
            else
            {
                next = true;
            }
        }
    }

    public void DisplayDialog(Dialog dialog, Action onDialogEnd = null)
    {
        indicator.DOKill();
        indicator.gameObject.SetActive(false);
        speakerText.text = dialog.speaker;
        dialogText.text = "";
        textDisplay = dialogText.DOText(dialog.dialog, textSpeed * dialog.dialog.Length).OnComplete(() =>
        {
            WaitForInput(onDialogEnd);
        });
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (textDisplay.IsPlaying())
        {
            textDisplay.Complete();
        }
        else
        {
            next = true;
        }
    }

    IEnumerator DisplayDialog(Action onDialogEnd)
    {
        indicator.gameObject.SetActive(true);
        indicator.DOColor(new Color(indicator.color.r, indicator.color.g, indicator.color.b, 0), 0.3f).SetLoops(-1, LoopType.Yoyo);
        while (!next)
        {
            yield return null;
        }
        onDialogEnd?.Invoke();
        next = false;
    }

    void WaitForInput(Action onDialogEnd)
    {
        StartCoroutine(DisplayDialog(onDialogEnd));
    }
}
