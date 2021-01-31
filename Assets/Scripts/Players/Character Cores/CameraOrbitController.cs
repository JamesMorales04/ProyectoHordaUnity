using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    public float lookSensitivity;
    public float minXLook;
    public float maxXLook;

    public Transform cameraTarget;
    public bool invertXRotation;

    private RaycastHit hit;
    private Vector3 cameraOffset;

    [Header("Layer(s) to include")]
    public LayerMask CamOcclusion;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraOffset = cameraTarget.localPosition;
    }

    //Metodo que se ejecuta al final de cada frame
    void LateUpdate()
    {

        // Obtiene los valores de X y Y que provee el mouse 
        float x = Input.GetAxis("Mouse X");

        //float y = Input.GetAxis("Mouse Y");


        // Rota al jugador de manera orizontal


        if (invertXRotation)
        {
            transform.eulerAngles -= Vector3.up * x * lookSensitivity;
        }
        else
        {
            transform.eulerAngles += Vector3.up * x * lookSensitivity;
        }

        if (Physics.Linecast(transform.position, transform.position + transform.localRotation * cameraOffset, out hit, CamOcclusion))
        {
            cameraTarget.localPosition = (new Vector3(0, 1.58f, -Vector3.Distance(transform.position, hit.point)));
        }
        else
        {

            cameraTarget.localPosition = Vector3.Lerp(cameraTarget.localPosition, cameraOffset, Time.deltaTime);
        }

        /*
         * Codigo para mover la camara en el eje Y, lo agrego aqui por si es de utilidad a futuro
         * currentXRotation += y * lookSensitivity;     
         * currentXRotation = Mathf.Clamp(currentXRotation, minXLook, maxXLook);
         * Vector3 clampedAngle = cameraTarget.eulerAngles;
         * clampedAngle.x = currentXRotation;
         * cameraTarget.eulerAngles = clampedAngle;
         */


    }
}