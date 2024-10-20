using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] GameObject[] puntos;
    [SerializeField] float velocidad;
    private int puntoActual = 0;
    private void Update()
    {
        // Distance calcula la distancia entre 2 posiciones
        // PARAM 1: posición del punto1 que no es visible en el juego
        // PARAM 2: posición del gameObject que tenga asociado este script. O sea, la plataforma.
        // Esta condición dará TRUE cuando la plataforma haya llegado al lugar del punto1
        if (Vector2.Distance(puntos[puntoActual].transform.position, transform.position) < 0.1f) {
            // Una vez que la plataforma ha llegado al punto1, le diremos que se mueva hacia el punto2
            puntoActual++;
            // Si punto actual supera la cantidad de elementos del arreglo, lo reseteo
            if (puntoActual > puntos.Length -1) {
                puntoActual = 0;
            }
        }

        // MoveTowars (mover hacia), calcula la posición hacia donde debe moverse un gameObject considerando
        // el punto desde donde está, hacia dónde quiere ir y a qué velocidad.
        // PARAM 1: posición actual del gameObject que quiero mover.
        // PARAM 2: posición objetivo hacia donde quiero que se mueva mi gameObject
        // PARAM 3: velocidad a la que se ejecutará la acción
        transform.position = Vector2.MoveTowards(transform.position, puntos[puntoActual].transform.position, velocidad * Time.deltaTime);
    }
    
}
