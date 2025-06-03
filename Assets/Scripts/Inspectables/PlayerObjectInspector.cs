using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectInspector : MonoBehaviour
{
    private InspectableObject inspectableObj;
    private InspectableObject instance;
    private ThirdPersonController thirdPersonController;

    [SerializeField] private Transform inspectableObjectInstantiatePosition;

    void Awake() {
       thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void Update() {
        if (inspectableObj != null && Input.GetKeyDown(KeyCode.E))
        {
            InspectObject();
        }

        if (instance != null)
        {
            RotateInspectedObject();

             if (Input.GetKeyDown(KeyCode.Escape))
            {
                StopInspecting();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        InspectableObject obj = coll.gameObject.GetComponent<InspectableObject>();

        if(obj == null)
        {
            return;
        }
    
        inspectableObj = obj;
    }

    void InspectObject() {
        instance = Instantiate(inspectableObj, inspectableObjectInstantiatePosition.position, Quaternion.identity);
        Collider collider = instance.GetComponent<Collider>();
        
        if (collider != null)
        {
            collider.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        thirdPersonController.enabled = false;
    }

    void StopInspecting()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;

        thirdPersonController.enabled = true;

        Destroy(instance.gameObject);
        instance = null;
    }

     void RotateInspectedObject()
    {
        float rotX = Input.GetAxis("Mouse X") * 100f * Time.unscaledDeltaTime;
        float rotY = Input.GetAxis("Mouse Y") * 100f * Time.unscaledDeltaTime;

        instance.transform.Rotate(Vector3.up, -rotX, Space.World);
        instance.transform.Rotate(Vector3.right, rotY, Space.World);
    }
}
