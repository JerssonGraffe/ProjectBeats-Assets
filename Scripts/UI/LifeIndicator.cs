using UnityEngine;

public class LifeIndicator : MonoBehaviour
{
    public PlayerBasement playerBasement; // Referencia al script PlayerBasement
    public int vidaParaDesactivar = 2; // Número de vida para desactivar el objeto

    void Update()
    {
        // Verifica si la vida del jugador es igual al valor especificado
        if (playerBasement != null)
        {
            if (playerBasement.vida == vidaParaDesactivar)
            {
                // Desactiva el objeto completo cuando la vida alcance el valor especificado
                gameObject.SetActive(false);
            }
        }
    }
}
