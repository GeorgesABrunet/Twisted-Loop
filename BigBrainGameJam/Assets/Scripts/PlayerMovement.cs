using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float JumpSpeed = 30f;
    private float gravity = 14.0f;
    private float VerticalVelocity;
    private bool IsCountering;
    private float CounterTime = 0.5f;
    private float RespawnTime = 3f;
    private bool IsAlive;
    private Animator anim;
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 SpawnPosition;
    private Quaternion SpawnRotation;
    void Start()
    {
        IsCountering = false;
        IsAlive = true;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        SpawnPosition = new Vector3(25, 3.3f, -12.5f);
        SpawnRotation = this.transform.rotation;
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.T))
            {
                Counter();
            }

        if(controller.isGrounded)
        {
            VerticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.R))
            {
                Jump();
            }
        } 

        else
        {
            VerticalVelocity -= 3 * gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, VerticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
    }

    void Jump()
    {
        anim.SetTrigger("Jumping");
        PostGameStats.Jumps = PostGameStats.Jumps + 1;
        VerticalVelocity = JumpSpeed;
    }

    void Counter()
    {
        IsCountering = true;
        anim.SetTrigger("Counter");
        PostGameStats.Smacks = PostGameStats.Smacks + 1;
        Invoke("ResetCounter", CounterTime);
    }

    void ResetCounter()
    {
        IsCountering = false;
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Needle"))
        {
            if (IsAlive == true)
            {
                if (IsCountering == false)
                {
                    Die();
                }
                else
                {
                    NeedleTurn.TurnSpeed = NeedleTurn.TurnSpeed * (-1);
                    IsCountering = false;
                }
            }
        }
	}
    void Respawn()
    {
        this.transform.position = SpawnPosition;
        this.transform.rotation = SpawnRotation;
        anim.SetBool("Rektd", false);
        IsAlive = true;
    }
    void Die()
    {
        anim.SetTrigger("Yeeted");
        anim.SetBool("Rektd", true);
        PlayerHealth.Lives = PlayerHealth.Lives - 1;
        IsAlive = false;
        Invoke("Respawn", RespawnTime);
    }
}
