using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] private Transform target;  // El objeto que se copiará como sombra
    [SerializeField] private Vector3 offset = new Vector3(0.1f, -0.1f, 0);  // Offset para dar efecto de sombra

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No se ha asignado un objeto para copiar en ShadowController.");
            return;
        }

        // Copiar posición, rotación y escala del objeto target, aplicando un offset para la posición
        transform.position = target.position + offset;
        transform.rotation = target.rotation;
        transform.localScale = target.localScale;
    }

    // Método para establecer el objeto target dinámicamente
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
