using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed=5f;
    public float lookSpeed=2.5f;
    public GameObject cam1P;
    public GameObject cam3P;
    bool cameraIs1P=false;
    public float jumpForce=5f;
    public int maxJumps=1;
    int jumps=1;
    float airborneY=0f;
    Rigidbody rb;
    Menu menu;
    public GameObject fireplace;



    //execution
    void Start()
    {
        if(rb==null){
            rb=GetComponent<Rigidbody>();
            menu=FindAnyObjectByType<Menu>();
        }
        ToggleCamera(); //set to 1P initially
        airborneY=transform.position.y;
    }
    void Update()
    {
        if(Time.timeScale!=0f){
            Move();
            Look();
            if(Input.GetKeyDown(KeyCode.Space) && jumps>0){
                Jump();
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse2)){
            ToggleCamera();
        }
        if(Input.GetKeyDown(KeyCode.G)){
            Instantiate(fireplace, transform.position, transform.rotation);
        }
    }

    //movement
    void Move(){
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement*moveSpeed*Time.deltaTime);
        if(!cameraIs1P){
            Vector3 rotation = new Vector3(0, 1, 0);
            if(Input.GetKey(KeyCode.E)){
                transform.Rotate(rotation*lookSpeed*50*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.Q)){
                transform.Rotate(rotation*lookSpeed*-50*Time.deltaTime);
            }
        }
    }
    float rotY = 0f;
    float rotX = 0f;
    void Look(){
        rotY += Input.GetAxis("Mouse X")*lookSpeed;
        rotX += Input.GetAxis("Mouse Y")*-lookSpeed;
        if(cameraIs1P){
            rotX = Mathf.Clamp(rotX, -90f, 90f);

            transform.localEulerAngles = new Vector3(0,rotY,0);
            cam1P.transform.localEulerAngles = new Vector3(rotX,0,0);
        } else {
            rotX = Mathf.Clamp(rotX, 0f, 90f);
            
            cam3P.transform.localEulerAngles = new Vector3(rotX,rotY,0);
        }
    }
    void Jump(){
        jumps--;
        rb.linearVelocity = transform.up*jumpForce;
    }
    void ToggleCamera(){
        cameraIs1P = !cameraIs1P; //toggle 1P and 3P views
        if(cameraIs1P){
            cam1P.SetActive(true);
            cam3P.SetActive(false);
        } else {
            cam1P.SetActive(false);
            cam3P.SetActive(true);
            cam3P.transform.localEulerAngles=new Vector3(0,0,0);
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Floor")){
            if((transform.position.y-airborneY)<=-30f){
                menu.Death();
            }
            jumps=maxJumps;
        }
    }
    void OnCollisionExit(Collision col){
        if(col.gameObject.CompareTag("Floor")){
            airborneY=transform.position.y;
        }
    }
}
