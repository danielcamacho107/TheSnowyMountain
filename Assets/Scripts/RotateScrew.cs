using UnityEngine;

public class RotateScrew : MonoBehaviour
{
    bool ready = false;
    bool upwards = true;
    public float rotationSpeed;
    public float rotationScale;
    public float translationSpeed;
    public float translationScale;
    public float maxY = 200f;
    Vector3 defaultRotation;
    Vector3 defaultPosition;
    public GameObject camera;
    public GameObject[] otherCameras;
    public GameObject returnCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultRotation = transform.localEulerAngles;
        defaultPosition = transform.position;
        camera.SetActive(false);
    }
    void Update()
    {
        if (ready && upwards && transform.position.y < maxY)
        {
            transform.Rotate(rotationScale * rotationSpeed * Time.deltaTime);
            transform.Translate(translationScale * translationSpeed * Time.deltaTime);
        } else if (ready && transform.position.y >= maxY)
        {
            upwards = false;
        }
        else if (ready && !upwards && transform.position.y > 1f)
        {
            transform.Rotate(-rotationScale * rotationSpeed * Time.deltaTime);
            transform.Translate(-translationScale * translationSpeed * Time.deltaTime);
        } else if (ready && !upwards && transform.position.y <= 1f)
        {
            camera.SetActive(false);
            returnCamera.SetActive(true);
        }
    }
    void BeReady()
    {
        ready = true;
        camera.SetActive(true);
        for(int i=0; i<otherCameras.Length; i++)
        {
            otherCameras[i].SetActive(false);
        }
    }
    void ResetTransform()
    {
        camera.SetActive(false);
        returnCamera.SetActive(true);
        transform.position = defaultPosition;
        transform.localEulerAngles = defaultRotation;
        ready = false;
        upwards = true;
    }
}
