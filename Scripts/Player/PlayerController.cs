using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    public Animator animator;
    public Animator animatorShadow;
    public float margin = 0.5f; // Margen para que el objeto no llegue al borde de la cámara
    public float followSpeed = 2f; //Factor de velocidad para hacer que el objeto se mueva más rápido que el mouse

    void Update()
    {
        // Detectar si se hace clic en cualquier parte de la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePosition.z = 0f; // Asegurar que el eje Z esté en 0 para evitar problemas en 2D
        }

        // Mover el objeto mientras se arrastra
        if (isDragging)
        {
            animator.SetBool("Active", true);  // Activa la animación si se está moviendo
            animatorShadow.SetBool("Active", true);

            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f; // Mantener en 2D

            // Calcular el desplazamiento del mouse desde la última posición
            Vector3 mouseDelta = (currentMousePosition - lastMousePosition) * followSpeed;

            // Mover el objeto en la misma dirección que el mouse se mueve
            Vector3 newPosition = transform.position + mouseDelta;

            // Limitar la posición del objeto dentro de los límites de la cámara con margen
            Vector3 cameraMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            Vector3 cameraMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

            // Aplicar margen a los límites de la cámara
            newPosition.x = Mathf.Clamp(newPosition.x, cameraMin.x + margin, cameraMax.x - margin);
            newPosition.y = Mathf.Clamp(newPosition.y, cameraMin.y + margin, cameraMax.y - margin);

            // Asignar la posición restringida
            transform.position = newPosition;

            // Actualizar la última posición del mouse
            lastMousePosition = currentMousePosition;
        }
        else
        {
            animator.SetBool("Active", false);
            animatorShadow.SetBool("Active", false);
        }

        // Dejar de arrastrar al soltar el botón del mouse
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
