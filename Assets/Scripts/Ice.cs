using UnityEngine;

public class Ice : MonoBehaviour
{
    public float slippyScale=2f;
    Player player;

    void Start(){
        if(player==null){
            player=FindAnyObjectByType<Player>();
        }
    }
    void OnColliderEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            player.moveSpeed*=slippyScale;
        }
    }
    void OnColliderExit(Collision col){
        if(col.gameObject.CompareTag("Player")){
            player.moveSpeed/=slippyScale;
        }
    }
}
