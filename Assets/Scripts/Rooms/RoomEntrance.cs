using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RoomEntrance : MonoBehaviour
{
    public RoomEntrance connectedEntrance;

    public Vector3 position
    {
        get
        {
            return transform.position;
        }
    }

    private bool _justArrived;

    private void Awake()
    {
        if(connectedEntrance != null && connectedEntrance.connectedEntrance == null)
        {
            connectedEntrance.connectedEntrance = this;
        }
    }

    public IEnumerator Teleport(GameObject teleportedObject)
    {
        yield return new WaitForSeconds(0.1f);
        _justArrived = true;
        teleportedObject.transform.position = new Vector2(position.x, position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !_justArrived)
        {
            StartCoroutine(connectedEntrance.Teleport(collision.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag.Equals("Player"))
        {
            _justArrived = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.2f, 0.6f, 0.9f, 0.5f);
        Gizmos.DrawCube(position, Vector3.one);
        Gizmos.color = Color.red;
        if (connectedEntrance)
        {
            Gizmos.DrawLine(position, connectedEntrance.position);
        }
    }
}
