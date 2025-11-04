using UnityEngine;
using TMPro;

public class UIMsg : MonoBehaviour
{
    public TMP_Text message;
    public float lifetime = 5f;
    float cleartime;
    bool canClear = true;



    //execution
    void Start()
    {
        ClearMsg();
    }
    void Update()
    {
        if(canClear&&Time.time>cleartime){
            ClearMsg();
        }
    }

    //message
    public void SayPersistent(string msg){
        canClear=false;
        message.text=msg;
    }
    public void Say(string msg){
        canClear=true;
        cleartime=Time.time+lifetime;
        message.text=msg;
    }
    public void ClearMsg(){
        canClear=false;
        message.text="";
    }
}
