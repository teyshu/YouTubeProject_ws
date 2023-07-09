using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class Magic : MonoBehaviour
    {
        protected bool isFire = false;
        protected bool isWater = false;
        protected bool isGround = false;
        [SerializeField] protected GameObject fire;
        [SerializeField] protected GameObject water;
        [SerializeField] protected GameObject ground;
        [SerializeField] private GameObject _camera;
        [SerializeField] private GameObject _magicImage;

        private Transform cameraTransform;
        private float _distanseSpellMin = 2f;
        private float _distanseSpellMax = 30f;
        float playerLookDistance = 10f;
        private float _cooldown = 4f;
        private bool _isAttack = true;

        private void Start()
        {
            cameraTransform = Camera.main.transform;
        }

        public void ReceiveMagicFire(int lvlMagic)
        {
            isFire = true;
            _magicImage.SetActive(true);
            print("Вам доступная магия огня. Нажмите Q, чтобы ее использовать!");
        }

        public void ReceiveMagicGround(int lvlMagic)
        {
            isGround = true;
            _magicImage.SetActive(true);
            print("Вам доступная магия земли. Нажмите Q, чтобы ее использовать!");
        }

        public void ReceiveMagicWater(int lvlMagic)
        {
            isWater = true;
            _magicImage.SetActive(true);
            print("Вам доступная магия воды. Нажмите Q, чтобы ее использовать!");
        }

        protected void MagicAttack()
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                RaycastHit hit;
                float playerLookDistance = Camera.main.fieldOfView;
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit))
                {
                    playerLookDistance = hit.distance;
                }



                Vector3 lookDirection = cameraTransform.forward;
                float spawnDistance = Mathf.Lerp(_distanseSpellMin, _distanseSpellMax, playerLookDistance / 50f);
                Vector3 spawnPosition = cameraTransform.position + lookDirection * spawnDistance;
                spawnPosition.y = 1f;

                if (_isAttack)
                {
                    if (isFire)
                    {
                        StartCoroutine(CoolownSpell());
                        var magicSpell = Instantiate(fire, spawnPosition, Quaternion.identity);
                        Destroy(magicSpell, _cooldown);
                    }
                    else if (isWater)
                    {
                        StartCoroutine(CoolownSpell());
                        var magicSpell = Instantiate(water, spawnPosition, Quaternion.identity);
                        Destroy(magicSpell, _cooldown);
                    }
                    else if (isGround)
                    {
                        StartCoroutine(CoolownSpell());
                        var magicSpell = Instantiate(ground, spawnPosition, Quaternion.identity);
                        Destroy(magicSpell, _cooldown);
                    }
                    else
                    {
                        print("Магия пока заблокирована!");
                    }
                }
                else
                {
                    print("Использовать магию пока нельзя!");
                }
            }
        }

        protected IEnumerator CoolownSpell()
        {
            _isAttack = false;
            yield return new WaitForSeconds(_cooldown);
            _isAttack = true;
        }

    }
}
