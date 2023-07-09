using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Image[] hearts;
    public int maxHealth = 3;
    [HideInInspector] public bool HasMoonshine;
    private int currentHealth;

    private void Start()
    {
        HasMoonshine = false;
        currentHealth = maxHealth;
    }

    public void DecreaseHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            hearts[currentHealth].enabled = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void IncreaseHealth()
    {
        if (currentHealth < maxHealth)
        {
            hearts[currentHealth].enabled = true;
            currentHealth++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            EventManager.OnLeftTheCastle();
        }
    }
}
