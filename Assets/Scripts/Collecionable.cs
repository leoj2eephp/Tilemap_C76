using UnityEngine;
using UnityEngine.UI;

public class CollecionablePlayer : MonoBehaviour
{
    // textItems recibe el valor desde Unity! Allá tenemos que arrastrar el Text hacia el espacio
    // que estará disponible en el Inspector del Player.
    [SerializeField] private Text textItems;
    private int contador = 0;
    // La única forma para que el juego entre a leer el código de un OnTrigger.. es que haya un
    // elemento Collider que tenga activado el atributo "Is Trigger"
    private void OnTriggerEnter2D(Collider2D other) {
        // other es el GameObject con el que estás "chocando".. como es un trigger, en realidad
        // lo estás traspasando, PERO sí se activa esta función cuando lo tocas.
        // Para identidicar específicamente cuál gameObject estás tocando, preguntamos qué
        // TAG tiene. En este caso, con el TAG Fruta identificamos los gameObjects fruta
        if (other.CompareTag("Fruta")) {
            // Destroy va a quitar de la escena cualquier GameObject que le entregues por parámetro
            // OJO: entregar solo other NO TE SERVIRÁ para eliminar el gameObject con el que estás interactuando.
            // TIenes que especificar que lo que se destruye es other.gameObject
            Destroy(other.gameObject);
            // Suma en uno la variable para la siguiente línea de código
            contador++;
            textItems.text = $"Ítems: {contador}";
        }
    }
}
