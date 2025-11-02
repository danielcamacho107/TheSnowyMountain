using UnityEngine;

public abstract class Pickupable : MonoBehaviour
{
    public float rotationSpeed=100f;
    public Vector3 rotationScale=new Vector3(0,1,0);



    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            onPickup();
        }
    }
    protected void Rotate(){
        transform.Rotate(rotationScale*rotationSpeed*Time.deltaTime);
    }
    protected abstract void onPickup();
}
