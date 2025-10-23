using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //stats
    int maxHP = 600; //5 mins
    int HP = 600;
    public float moveSpeed = 5f;
    public float lookSpeed = 2.5f;
    public float jumpForce = 5f;
    int jumps = 1;
    public int maxJumps = 1;

    //componentes y dependencias
    Rigidbody rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHP;
        jumps = maxJumps;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            Move();
            Look();
            if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
            {
                Jump();
            }
        }
    }

    //movimiento
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    float rotY = 0f;
    float rotX = 0f;
    void Look()
    {
        rotY += Input.GetAxis("Mouse X") * lookSpeed;
        rotX += Input.GetAxis("Mouse Y") * -lookSpeed;

        rotX = Mathf.Clamp(rotX, -90f, 90f);

        transform.localEulerAngles = new Vector3(0, rotY, 0);
        Camera.main.transform.localEulerAngles = new Vector3(rotX, 0, 0);
    }
    void Jump()
    {
        jumps--;
        rb.linearVelocity = transform.up * jumpForce;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            jumps = maxJumps;
        }
    }

    //setters y getters
    public int getMaxHP()
    {
        return HP;
    }
    public int getHP()
    {
        return HP;
    }
    public void addHP(int amount)
    {
        HP += amount;
        if (HP > maxHP)
        {
            HP = maxHP;
        }
        //update hp ui
    }
    public void raiseHP(int amount)
    {
        maxHP += amount;
        //update hp ui
    }
    public void TakeDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            HP = 0;
            Die();
        }
        //update hp ui
    }
    void Die()
    {
        Destroy(gameObject);
        //replace with call to UI deathmenu
    }
} //fin
