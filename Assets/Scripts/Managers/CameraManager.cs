using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera m_levelCamera;
    [SerializeField] private Transform m_levelFocalPoint;
    [SerializeField] private float m_cameraRotateSpeed;
    [SerializeField] private float m_cameraZoomSpeed;

    private void Start()
    {
        m_levelCamera.transform.LookAt(m_levelFocalPoint);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RotateAround(m_cameraRotateSpeed);
        }       
        if (Input.GetMouseButton(1))
        {
            RotateAround(-m_cameraRotateSpeed);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            Zoom(m_cameraZoomSpeed);
        }        
        if (Input.mouseScrollDelta.y < 0)
        {
            Zoom(-m_cameraZoomSpeed);
        }
    }

    private void RotateAround(float rotateAmount)
    {
        m_levelCamera.transform.RotateAround(m_levelFocalPoint.position, Vector3.up, rotateAmount * Time.deltaTime);
    }

    private void Zoom(float zoomAmount)
    {
        m_levelCamera.transform.position = Vector3.MoveTowards(m_levelCamera.transform.position, m_levelFocalPoint.position, zoomAmount * Time.deltaTime);
    }
}
