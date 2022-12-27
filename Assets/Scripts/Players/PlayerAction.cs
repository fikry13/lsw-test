using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerAction : MonoBehaviour
{
    public bool canAct;

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && canAct)
        {
            Debug.Log("Acted");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interactable"))
        {
            canAct = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interactable"))
        {
            canAct = false;
        }
    }
}
