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
        // ���������, ����� �� ��������
        bool canShoot = Time.time >= nextFireTime;

        if (Input.GetMouseButton(0) && canShoot)
        {
            // �������� ������
            ShootPotion();
            // ������������� ����� ���������� ��������
            nextFireTime = Time.time + 1f / fireRate;
        }
        else
        {
            broomAnimator.SetTrigger("Idle");
        }
    }

    private void ShootPotion()
    {
        // ������� ��������� �����
        GameObject potion = Instantiate(potionPrefab, potionSpawnPoint.position, potionSpawnPoint.rotation);
        // ������ �������� �����
        Rigidbody potionRigidbody = potion.GetComponent<Rigidbody>();
        potionRigidbody.velocity = potionSpawnPoint.forward * potionSpeed * -1f;
        // ��������� ��������
        if (broomAnimator != null)
        {
            broomAnimator.SetTrigger("BroomShoot");
        }
    }
}
