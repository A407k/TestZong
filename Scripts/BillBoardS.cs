using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillBoardS : MonoBehaviour
{
    public Transform cam;

    public Canvas BillCan;
    public float activationDistance = 5f; // Distance at which the canvas should be activated

    private void LateUpdate()
    {
        // Rotate the canvas to face the camera
        BillCan.transform.LookAt(BillCan.transform.position + cam.forward);

        // Check the distance between the player and the billboard
        float distanceToPlayer = Vector3.Distance(transform.position, cam.position);

        // Enable or disable the canvas based on the distance
        if (distanceToPlayer <= activationDistance)
        {

            CanvasScaler canvasScaler = BillCan.GetComponent<CanvasScaler>();

            canvasScaler.dynamicPixelsPerUnit = 142;

            BillCan.enabled = true;
        }
        else
        {
            BillCan.enabled = false;
        }
    }
}
