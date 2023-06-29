using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThing : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _distanse;
    private GameObject _currentThing;
    private bool _canPeekUp;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!_canPeekUp)
                PickUp();
            else
                Drop();
        }
    }

    private void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distanse))
        {
            if (hit.transform.tag == "PickUp")
            {
                if (_canPeekUp)
                    Drop();

                _currentThing = hit.transform.gameObject;
                _currentThing.GetComponent<Rigidbody>().isKinematic = true;
                _currentThing.transform.parent = transform;
                _currentThing.transform.localPosition = Vector3.zero;
                _currentThing.transform.localEulerAngles = new Vector3(10f, 0f, 0f);

                _canPeekUp = true;
            }

        }
    }

    private void Drop()
    {
        var _cRb = _currentThing.GetComponent<Rigidbody>();
        _currentThing.transform.parent = null;
        _currentThing.GetComponent<Rigidbody>().isKinematic = false;
        _canPeekUp = false;
        _currentThing = null;
    }
}
