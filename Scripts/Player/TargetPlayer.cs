using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public Transform target;  // El objeto que será seguido
    public float smoothSpeed = 0.125f;  // Velocidad de suavizado
    public Vector3 offset;  // Desplazamiento opcional entre los objetos
    public bool lookAtTarget = true;  // Indica si el objeto debe rotar para mirar al objetivo

    void LateUpdate()
    {
        if (target != null)
        {
            // Posición deseada del objeto (con desplazamiento)
            Vector3 desiredPosition = target.position + offset;

            // Interpolación lineal para suavizar el movimiento
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Asignar la posición suavizada
            transform.position = smoothedPosition;

            // Girar para mirar al objetivo
            if (lookAtTarget)
            {
                Vector3 direction = target.position - transform.position; // Vector de dirección hacia el objetivo
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Calcular el ángulo en grados
                transform.rotation = Quaternion.Euler(0, 0, angle); // Aplicar la rotación en el eje Z
            }
        }
    }
}
