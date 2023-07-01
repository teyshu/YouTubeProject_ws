using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonshine : MonoBehaviour
{
    private GameObject _moonshinePanel;
    [SerializeField] private GameObject _model;

    void Start()
    {
        _moonshinePanel = GameObject.Find("Moonshine panel");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Notificate());
            PlayerStats health = collision.gameObject.GetComponent<PlayerStats>();
            health.HasMoonshine = true;
            _model.SetActive(false);
        }
    }

    private IEnumerator Notificate()
    {
        _moonshinePanel.GetComponent<CanvasGroup>().alpha = 1;
        yield return new WaitForSeconds(5f);
        _moonshinePanel.GetComponent<CanvasGroup>().alpha = 0;
        Destroy(gameObject);
    }
}
