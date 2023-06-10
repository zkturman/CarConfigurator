using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponApplicator : MonoBehaviour
{
    [SerializeField]
    private Vector3 weaponAttachmentPoint;
    GameObject attachedWeapon;

    public void AddWeapon(GameObject weaponPrefab)
    {
        if (attachedWeapon != null)
        {
            Destroy(attachedWeapon);
        }
        attachedWeapon = Instantiate(weaponPrefab, transform);
        WeaponAttachment weaponPoint = attachedWeapon.GetComponent<WeaponAttachment>();
        attachedWeapon.transform.localPosition = transform.TransformPoint(weaponAttachmentPoint)
            - weaponPoint.AttachmentPosition;
    }

    public void RemoveWeapon()
    {
        if (attachedWeapon != null)
        {
            Destroy(attachedWeapon);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = transform.position + weaponAttachmentPoint;
        Gizmos.DrawSphere(position, .2f);
    }
}
