using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class PauseGameButton : MonoBehaviour
{
    public GameObject objectToActivate; // El objeto que se activará al pausar
    public TargetPlayer targetPlayerScript; // Referencia al script TargetPlayer
    public PlayerController playerControllerScript; // Referencia al script PlayerController

    private bool isGamePaused = false;

    void Start()
    {
        // Asegura que el objeto esté inactivo al iniciar
        objectToActivate.SetActive(false);
    }

    public void OnButtonPress()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            objectToActivate.SetActive(true); // Activa el objeto
            Time.timeScale = 0; // Pausa el juego

            // Desactiva los scripts
            targetPlayerScript.enabled = false;
            playerControllerScript.followSpeed = 0f;
        }
        else
        {
            objectToActivate.SetActive(false); // Desactiva el objeto
            Time.timeScale = 1; // Reanuda el juego

            // Reactiva los scripts
            targetPlayerScript.enabled = true;
            playerControllerScript.followSpeed = 1.6f;
        }
    }

    // Función para reiniciar la escena actual
    public void RestartScene()
    {
        Time.timeScale = 1; // Asegura que el tiempo esté en escala normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }
}