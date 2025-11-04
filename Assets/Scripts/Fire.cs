using UnityEngine;

public class Fire : MonoBehaviour
{
    public string burningMsg = "You're burning!";
    public float burnTime = 3f;
    float deathTime;
    bool burnCheck = false;
    UIMsg uimsg;
    Menu menu;

    //execution
    void Start()
    {
        if(uimsg==null){
            uimsg=FindAnyObjectByType<UIMsg>();
            menu=FindAnyObjectByType<Menu>();
        }
    }
    void Update()
    {
        if(burnCheck && Time.time > deathTime){
            menu.Death();
        }
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            uimsg.Say(burningMsg);
            //start countdown
            deathTime=Time.time + burnTime;
            burnCheck=true;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("Player")){
            uimsg.ClearMsg();
            //stop countdown
            burnCheck=false;
        }
    }
}
