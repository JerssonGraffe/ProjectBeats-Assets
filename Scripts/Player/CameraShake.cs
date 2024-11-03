using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeForce = 0.5f;     // Fuerza del temblor
    public float shakeDuration = 1f;    // Duración en segundos del temblor
    public bool isShaking = false;      // Variable booleana para activar/desactivar el temblor

    private float shakeTimer;           // Temporizador interno
    private Vector3 originalPosition;    // Posición original de la cámara

    void Start()
    {
        // Guardamos la posición inicial de la cámara
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Inicia el temblor si isShaking está activado y el temporizador no ha comenzado
        if (isShaking && shakeTimer <= 0)
        {
            shakeTimer = shakeDuration;
        }

        // Si el temporizador está en marcha, temblamos la cámara
        if (shakeTimer > 0)
        {
            transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeForce;
            shakeTimer -= Time.deltaTime;

            // Si el temporizador termina, restablecemos la posición y detenemos el temblor
            if (shakeTimer <= 0)
            {
                transform.localPosition = originalPosition;
                isShaking = false;
            }
        }
    }
}
