using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo)) {
            if (hitInfo.collider != null) {
                Debug.Log(hitInfo.collider.gameObject.name);
               // _camera.rotation = Quaternion.LookRotation(hitInfo.point);
            }
        }
    }
}
