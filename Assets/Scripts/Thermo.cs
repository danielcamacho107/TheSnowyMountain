using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class Thermo : MonoBehaviour
{
    //stats
    public int HP = 2400; //5 mins
    public int maxHP = 2400;
    public int bleedScale = 1;
    public float dmgCD = 0.125f; //eighth second
    float dmgICD = 0f;
    public Light light;

    //import
    Menu menu;
    public Image HPBar;
    public TMP_Text HPTx;


    //execution
    void Start()
    {
        HP=maxHP;
        if(menu==null){
            menu=FindAnyObjectByType<Menu>();
        }
    }
    void Update()
    {
        if(Time.timeScale!=0f && Time.time>dmgICD){
            Bleed();
        }
    }

    void Bleed(){
        dmgICD = Time.time + dmgCD;
        HP-=bleedScale;
        
        if(HP<=0){
            HP=0;
            menu.Death();
        } else if(HP>maxHP){
            HP=maxHP;
        }
        UpdateThermoUI();
    }
    public void AddHeat(int value){
        HP+=value;

        if(HP<=0){
            HP=0;
            menu.Death();
        } else if(HP>maxHP){
            HP=maxHP;
        }
        UpdateThermoUI();
    }
    public void SetBleedScale(int value){
        bleedScale=value;
    }
    void UpdateThermoUI(){
        HPBar.fillAmount = (float)HP/maxHP;
        //Debug.Log("div is:" + (float)HP/maxHP);
        HPTx.text = "" + HP + "/" + maxHP;
        light.colorTemperature = 18000-(HP*5);
    }
}
