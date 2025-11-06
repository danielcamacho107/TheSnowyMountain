using UnityEngine;

public class AnimatedPlayer : MonoBehaviour
{
    Animator animator;
    Player player;


    // exce
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
    }
    void Update()
    {
        animator.SetFloat("SpeedX", player.moveX * player.moveSpeed * Time.deltaTime);
        animator.SetFloat("SpeedZ", player.moveZ * player.moveSpeed * Time.deltaTime);
        animator.SetBool("isRunning", player.isRunning);
        animator.SetBool("isJumping", player.isJumping);
    }
}
