using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingridient : MonoBehaviour
{
    [SerializeField] public string element;
    [SerializeField] public GameObject particleFood;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boiler")
        {
            if(collision.gameObject.GetComponent<Boiler>().canCook)
                collision.gameObject.GetComponent<Boiler>().AddIngridient(this);
            gameObject.SetActive(false);
            var particle = Instantiate(particleFood, transform.position,Quaternion.identity);
            Destroy(particle, 3f);
        }
    }
}
