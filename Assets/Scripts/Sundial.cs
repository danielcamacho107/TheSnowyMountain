using UnityEngine;

public class Sundial : MonoBehaviour
{
    public float cycleDuration = 240f; //4 mins
    float tickCD;
    float tickICD=0f;
    Vector3 rotation=new Vector3(0,0,1);
    Thermo thermo;
    bool isNight=false;
    public int nightColdScale=3;
    


    //execution
    void Start()
    {
        tickCD=cycleDuration/360;
        if(thermo==null){
            thermo=FindAnyObjectByType<Thermo>();
        }
    }
    void Update()
    {
        if(Time.timeScale!=0 && Time.time>tickICD){
            tickICD=Time.time+tickCD;
            transform.Rotate(rotation);
            transform.localEulerAngles=new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Repeat(transform.localEulerAngles.z, 360f));
            if(transform.localEulerAngles.z>=180 && !isNight){
                isNight=true;
                thermo.bleedScale+=nightColdScale;
            } else if(transform.localEulerAngles.z<180 && isNight){
                isNight=false;
                thermo.bleedScale-=nightColdScale;
            }
        }
    }
}
