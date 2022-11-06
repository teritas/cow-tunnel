using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCheck : MonoBehaviour
{
    [SerializeField] private LayerMask boundaryLayerMask;

    public bool isBoundary;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isBoundary = collider != null && (((1 << collider.gameObject.layer) & boundaryLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isBoundary = false;
    }
}
