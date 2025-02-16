using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.LightTransport;
using UnityEngine.VFX;

public class DragWithMouse : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private Rigidbody _rb;
    private Vector3 _nextPosition;

    bool grab;
    bool zooming;

    public float rotatespeed = 100f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {    
        //if 
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        _offset = gameObject.transform.position -
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));

        _rb.isKinematic = true;

        _nextPosition = Vector3.zero;

        grab = true;
        
    }

    private void Update()
    {
        if(grab == true)
        {
            //Rotation
            //////////
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.right, rotatespeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.left, rotatespeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.down, rotatespeed * Time.deltaTime);
            }

            //Destroy
            /////////
            if (Input.GetKey(KeyCode.Backspace))
            {
                Destroy(gameObject);
            }

            //Zoom in/out
            ////
            Vector3 zoomPosition;
            if(Input.GetKey(KeyCode.UpArrow))
            {
                zoomPosition = transform.position;
                transform.position += new Vector3(0f, 0f, (3f * Time.deltaTime));
                zooming = true;
                _nextPosition = zoomPosition;

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                zoomPosition = transform.position;
                transform.position += new Vector3(0f, 0f, (-3f * Time.deltaTime));
                zooming = true;
                _nextPosition = zoomPosition;
            }

            //if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
            //{
                
            //}

        }
    }
        
    

    void OnMouseDrag()
    {
        //if (zooming)
        //{
        //    _rb.isKinematic = true;
        //}
        if (!zooming)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
            _nextPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
        }
        
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
        grab = false;
        zooming = false;
    }
}
