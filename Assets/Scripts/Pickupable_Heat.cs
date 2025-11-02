using UnityEngine;

public class Pickupable_Heat : Pickupable
{
    public int heal=600;
    Thermo thermo;
    


    //execution
    void Start()
    {
        if(thermo==null){
            thermo=FindAnyObjectByType<Thermo>();
        }
    }
    void Update()
    {
        Rotate();
    }

    protected override void onPickup(){
        thermo.AddHeat(heal);
        Destroy(gameObject);
    }
}
