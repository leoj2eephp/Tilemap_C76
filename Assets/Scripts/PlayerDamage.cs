using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] Text textVida;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D fisicas;
    private int vida;
    void Start()
    {
        vida = 100;
        animator = GetComponent<Animator>();
        fisicas = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Espinas")) {
            vida--;
            textVida.text = $"VIDA: {vida}";
            Perder();
        }
    }

    public void Perder() {
        if (vida <= 0) {
            animator.SetTrigger("perder");
            // Cambiamos el bodyType a Static para que el personaje no se pueda mover
            fisicas.bodyType = RigidbodyType2D.Static;
        }
    }

    public void ReiniciarScene() {
        SceneManager.LoadScene("SampleScene");
    }
    
}
