using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerAction : MonoBehaviour
{
    public bool canAct;
    private Interactable currentInteractable;

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && currentInteractable != null && canAct)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interactable"))
        {
            currentInteractable = collision.GetComponent<Interactable>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interactable"))
        {
            currentInteractable = collision.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interactable"))
        {
            currentInteractable = null;
        }
    }
}
