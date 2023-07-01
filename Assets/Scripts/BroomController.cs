using UnityEngine;

public class BroomController : MonoBehaviour
{
    public GameObject potionPrefab;
    public Transform potionSpawnPoint;
    public float potionSpeed = 10f;
    public float fireRate = 1f;
    public Animator broomAnimator;

    private float nextFireTime;

    private void Update()
    {
        // Проверяем, можно ли стрелять
        bool canShoot = Time.time >= nextFireTime;

        if (Input.GetMouseButton(0) && canShoot)
        {
            // Стреляем зельем
            ShootPotion();
            // Устанавливаем время следующего выстрела
            nextFireTime = Time.time + 1f / fireRate;
        }
        else
        {
            broomAnimator.SetTrigger("Idle");
        }
    }

    private void ShootPotion()
    {
        // Создаем экземпляр зелья
        GameObject potion = Instantiate(potionPrefab, potionSpawnPoint.position, potionSpawnPoint.rotation);
        // Задаем скорость зелья
        Rigidbody potionRigidbody = potion.GetComponent<Rigidbody>();
        potionRigidbody.velocity = potionSpawnPoint.forward * potionSpeed * -1f;
        // Запускаем анимацию
        if (broomAnimator != null)
        {
            broomAnimator.SetTrigger("BroomShoot");
        }
    }
}
