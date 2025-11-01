using UnityEngine;

public class Hearth : MonoBehaviour
{
    //public float heatCD=1;
    //float heatICD;
    Thermo thermo;
    public int heatScale=2;
    //bool isHeating=false;


    //execution
    void Start()
    {
        if(thermo==null){
            thermo=FindAnyObjectByType<Thermo>();
        }
    }
    /*void Update()
    {
        if(Time.timeScale!=0f && isHeating && Time.time>heatICD){
            heatICD=Time.time+heatCD;
            thermo.AddHeat(heatScale);
        }
    }*/
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            //isHeating=true;
            thermo.bleedScale-=heatScale;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.CompareTag("Player")){
            //isHeating=false;
            thermo.bleedScale+=heatScale;
        }
    }
}
