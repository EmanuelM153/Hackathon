using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    // Propiedades públicas que definen las estadísticas básicas del personaje
    public int maxHealth = 100;       // Salud máxima del personaje
    private int currentHealth;         // Salud actual del personaje
    public int attackPower = 10;      // Poder de ataque del personaje
    public int defense = 5;           // Defensa del personaje

    private SpriteRenderer _renderer;

    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Evento para manejar la muerte del personaje
    public delegate void OnDeath();
    public event OnDeath onDeath;


    // Start is called before the first frame update
    void Start()
    {

        // Iniciar la salud actual con la salud máxima al principio del juego
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Método para recibir daño, que reduce la salud del personaje
    public void TakeDamage(int damage)
    {
        // Calcular el daño neto después de aplicar la defensa
        int damageTaken = Mathf.Max(damage - defense, 0);

        // Reducir la salud actual por el daño tomado
        currentHealth -= damageTaken;

        StartCoroutine("VisualDamage");

        // Verificar si la salud ha llegado a cero
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }


    // Método para curar al personaje
    public void Heal(int healAmount)
    {
        // Incrementar la salud actual, pero no superar la salud máxima
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }

    // Método que se llama cuando la salud llega a cero
    void Die()
    {
        // Verifica si hay algún método suscrito al evento de muerte
        if (onDeath != null)
        {
            onDeath.Invoke();
        }

        // Aquí puedes añadir lógica adicional, como desactivar al personaje, jugar una animación, etc.
        Debug.Log("Character has died.");
        // Por ejemplo, para desactivar el GameObject:
        gameObject.SetActive(false);
    }

    private IEnumerator VisualDamage(){
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.color = Color.white;
    }

}
