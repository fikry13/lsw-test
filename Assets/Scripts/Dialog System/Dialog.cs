using System;
using UnityEngine;

[Serializable]
public class Dialog
{
    public string speaker;
    [Multiline(3)]
    public string dialog;
}
