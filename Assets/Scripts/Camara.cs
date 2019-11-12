using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coloca el script en el menu de la camara
[AddComponentMenu(V)]

public class Camara : MonoBehaviour
{
    private const string V = "Camera-Control/Smooth Follow CSharp";

    // Indica el objeto a seguir
    public Transform target;
    // Elige la distancia del objetivo en el plano X-Y
    public float distance = 10.0f;
    // Altura de la camara respecto al objeto.
    public float height = 5.0f;
    // 
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    void LateUpdate()
    {
        // Salida si no tenemos el objeto
        if (!target)
            return;

        // Calcula los angulos de rotación
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Modera la rotacion en el eje Y
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Modera la altura
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convierte un angulo en una rotación
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Establece la posición de la cámara en el plano x-z a una distancia de metros detrás del objeto
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Establece la altura de la cámara
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Siempre mira el objeto
        transform.LookAt(target);
    }
}
