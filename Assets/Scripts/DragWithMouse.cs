using System.Drawing;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.LightTransport;

public class DragWithMouse : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private Rigidbody _rb;
    private Vector3 _nextPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        _offset = gameObject.transform.position -
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));

        _rb.isKinematic = true;

        _nextPosition = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        _nextPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_nextPosition, Vector3.zero) > 0.01f)
        {
            _rb.position = _nextPosition; //physics method fixed update
        }
    }

    private void OnMouseUpAsButton()
    {
        _rb.isKinematic = false;
        _nextPosition = Vector3.zero;
    }
}
