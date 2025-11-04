using UnityEngine;

public class Fireplace : MonoBehaviour
{
    //components
    public GameObject fire;
    public Light firelight;
    UIMsg uimsg;

    //fuel
    public GameObject[] fuelTypes;
    public int fuelQuantity = 1;
    int fuelStored = 0;
    public float fuelLifetime = 12f;
    float fuelICD = 0f;

    //brightness
    float maxBrightness;
    float currentBrightness = 0f;
    float brightnessStep = 1f;
    float brighterCD = 0.125f;
    float brighterICD = 0f;

    //flags
    bool interactable = false;
    bool burning = false;



    //execution
    void Start(){
        if(uimsg==null){
            uimsg=FindAnyObjectByType<UIMsg>();
        }
        if(fire==null || firelight==null){
            Debug.Log("Fireplace: Please assign fire components!");
        }else{
            maxBrightness=firelight.intensity;
        }
        if(fuelTypes.Length==0){
            Debug.Log("Fireplace: Warning: fuel not set, switching to fuelless system!");
        }
        InstantSnuffing();
    }
    void Update(){
        Debug.Log("Interactable:" + interactable + ", Burning: " + burning + ", Fuel: " + fuelStored + ", Intensity: " + currentBrightness);
        if(burning){
            if(currentBrightness<maxBrightness && fuelStored>0){
                BecomeBrighter();
            }else if(currentBrightness>0 && fuelStored<=0){
                BecomeDimmer();
            }
            if(fuelStored>0){
                ConsumeFuel();
            }
        }

        if(interactable && Input.GetKeyDown(KeyCode.Mouse0) && fuelTypes.Length==0){
            AddFuel(6);
        }else if(interactable && Input.GetKeyDown(KeyCode.Mouse0)){
            //take matz from inv or say:
            uimsg.Say("Missing materials...");
        }
        if(interactable && Input.GetKeyDown(KeyCode.Mouse1) && fuelStored>0){
            if(burning==false){
                burning=true;
                fire.SetActive(true);
            }else{ //burning==true
                InstantSnuffing();
            }
        }else if(interactable && Input.GetKeyDown(KeyCode.Mouse1)){
            uimsg.Say("This fireplace has no fuel!");
        }
    }
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            interactable=true;
            if(fuelTypes.Length==0){
                uimsg.Say("[RMB] Turn on fireplace\n[LMB] Add fuel");
            }else{
                uimsg.Say("[RMB] Turn on fireplace (Requires fuel ×" + fuelQuantity + ")\n[LMB] Add fuel");
            }
        }
    }
    void OnTriggerExit(Collider col){
        if(col.gameObject.CompareTag("Player")){
            interactable=false;
            uimsg.ClearMsg();
        }
    }

    //fuel
    void AddFuel(int value){
        fuelStored+=value;
    }
    void ConsumeFuel(){
        if(Time.time>fuelICD){
            fuelICD=Time.time+fuelLifetime;
            fuelStored--;
            if(fuelStored<=0){
                fuelStored=0;
            }
        }
    }
    
    //brighter
    void BecomeBrighter(){
        if(Time.time>brighterICD){
            brighterICD=Time.time+brighterCD;
            currentBrightness+=brightnessStep;
            if(currentBrightness>maxBrightness){
                currentBrightness=maxBrightness;
            }
            firelight.intensity=currentBrightness;
        }
    }
    void BecomeDimmer(){
        if(Time.time>brighterICD){
            brighterICD=Time.time+brighterCD;
            currentBrightness-=brightnessStep;
            if(currentBrightness<=0){
                currentBrightness=0;
                burning=false;
                fire.SetActive(false);
            }
            firelight.intensity=currentBrightness;
        }
    }
    void InstantSnuffing(){
        currentBrightness=0;
        firelight.intensity=currentBrightness;
        burning=false;
        fire.SetActive(false);
    }
}