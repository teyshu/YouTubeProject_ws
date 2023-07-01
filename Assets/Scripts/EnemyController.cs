using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public float movementSpeed = 2f;
    public float rotationSpeed = 5f;
    [SerializeField] private int _maxHp;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Image _enemyImg;
    [SerializeField] private GameObject _moonshinePrefab;

    private Animation _animation;
    private float _currentHp;
    private PlayerStats _health;
    private bool _isAttacking = false;
    private void Start()
    {
        _isAttacking = false;
        _animation = GetComponent<Animation>();
        _currentHp = _maxHp;
        _health = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && _isAttacking == false)
        {
            StartCoroutine(Attack());
        }
        else
        {
           if(_isAttacking == false)
                FollowPlayer();
        }
    }

    private IEnumerator Attack()
    {
        _isAttacking = true;
        GetComponent<Animation>().Play("attack");
        yield return new WaitForSeconds(0.8f);
        _health.DecreaseHealth();
        _isAttacking = false;
    }

    private void FollowPlayer()
    {
        GetComponent<Animation>().Play("walk");
        transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
    }

    private IEnumerator ActivateHitEffect()
    {
        if (_hitEffect.activeInHierarchy == false)
            _hitEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        _hitEffect.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pumpkin")
        {
            StartCoroutine(ActivateHitEffect());
            _currentHp -= 1;
            _enemyImg.fillAmount = _currentHp / _maxHp;
            if (_currentHp <= 0)
            {
                Instantiate(_moonshinePrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
                
        }
    }


}
