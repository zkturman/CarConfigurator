using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachment : MonoBehaviour
{
    [SerializeField]
    private Vector3 attachmentPosition;
    public Vector3 AttachmentPosition { get => transform.TransformPoint(attachmentPosition); }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.TransformPoint(attachmentPosition), .2f);
    }

}
