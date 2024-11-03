using System.Collections;
using UnityEngine;

public class PlayerBasement : MonoBehaviour
{
    public int vida = 3; // Cantidad de vida inicial
    public bool isInvulnerable = false; // Controla si el jugador está en invulnerabilidad
    public float invulnerableDuration = 3f; // Duración de la invulnerabilidad en segundos

    public PlayerController Controlador;
    public BoxCollider2D ColiderPlayer;
    public GameObject ParticulasDeath;
    public SpriteRenderer PlayerSprite;
    public SpriteRenderer PlayerShadowSprite;

    public Animator AnimDano;

    public CameraShake Shake;

    public Animator SplashCamera;

    public AudioSource AudioDamage;

    void Start()
    {
        ParticulasDeath.SetActive(false);
        Application.targetFrameRate = 60; // Define la tasa de cuadros para 60 FPS
        QualitySettings.vSyncCount = 0; // Desactiva el V-Sync para que la configuración de FPS funcione
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Obs" && !isInvulnerable)
        {
            RestarVida();
        }
    }

    void OnParticleCollision(GameObject other)
    {

        if (other.CompareTag("Obs") && !isInvulnerable) 
        {
            RestarVida();
        }
    }

    void RestarVida(){

        vida -= 1;
        Debug.Log("Impacto");
        Shake.isShaking = true;
        AudioDamage.Play();

        if (vida <= 0)
        {
            Controlador.enabled = false;
            Time.timeScale = 0.1f;
            ParticulasDeath.SetActive(true);
            ColiderPlayer.enabled = false;
            PlayerSprite.enabled = false;
            PlayerShadowSprite.enabled = false;
            StartCoroutine(SplashCameraDisable());
        }
        else
        {
            StartCoroutine(InvulnerabilityCooldown());
            StartCoroutine(SplashCameraDisable());
        }
    }

    private IEnumerator InvulnerabilityCooldown()
    {
        isInvulnerable = true;
        AnimDano.SetBool("Dano", true);
        yield return new WaitForSeconds(invulnerableDuration);
        isInvulnerable = false;
        AnimDano.SetBool("Dano", false);
    }

    private IEnumerator SplashCameraDisable()
    {
        SplashCamera.SetBool("Active", true);
        yield return new WaitForSeconds(0.2f);
        SplashCamera.SetBool("Active", false);
    }
}
