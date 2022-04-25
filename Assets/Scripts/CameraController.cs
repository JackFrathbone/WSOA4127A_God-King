using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _cam;
    private float _camSize;
    private Vector2 _dragOrigin;

    [Header("Settings")]
    [SerializeField] private float _panSpeed;

    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private float _minCamSize;
    [SerializeField] private float _maxCamSize;

    //Sets the limits of the camera
    [SerializeField] private float _camMinX;
    [SerializeField] private float _camMinY;
    [SerializeField] private float _camMaxX;
    [SerializeField] private float _camMaxY;



    private void Start()
    {
        _cam = Camera.main;
        _camSize = _cam.orthographicSize;
    }

    private void Update()
    {
        Zoom();
        PanCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = _cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = _dragOrigin - (Vector2)_cam.ScreenToWorldPoint(Input.mousePosition);

            _cam.transform.position = ClampCamera(_cam.transform.position + difference);
        }
    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            _camSize -= scroll * _zoomSpeed;
            _camSize = Mathf.Clamp(_camSize, _minCamSize, _maxCamSize);
        }

        _cam.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, _camSize, _smoothSpeed * Time.deltaTime);
    }


    private Vector3 ClampCamera(Vector2 targetPosition)
    {
        float camHeight = _cam.orthographicSize;
        float camWidth = _cam.orthographicSize * _cam.aspect;

        float minX = _camMinX + camWidth;
        float maxX = _camMaxX - camWidth;

        float minY = _camMinY + camWidth;
        float maxY = _camMaxY - camWidth;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX,newY, -10f);
    }
}
