using UnityEngine;

public abstract class Pickupable : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Vector3 rotationScale = new Vector3(0, 1, 0);
    public float decayTime = 0.0f; //set to 0 or negative for no decay


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if()
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    protected void Rotate()
    {
        transform.Rotate(rotScl * rotSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            onPickup();
        }
    }

    protected abstract void onPickup();
}
