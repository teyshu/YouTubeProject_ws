using UnityEngine;

public class BoilerZone : MonoBehaviour
{
    public GameObject interactionPrompt;

    private Animator animator;
    private bool isPlayerInRange;
    private PlayerStats _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerStats>();
        animator = GetComponent<Animator>();
        interactionPrompt.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.enabled = true;
                Destroy(interactionPrompt);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & _player.HasMoonshine)
        {
            isPlayerInRange = true;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionPrompt.SetActive(false);
        }
    }
}
