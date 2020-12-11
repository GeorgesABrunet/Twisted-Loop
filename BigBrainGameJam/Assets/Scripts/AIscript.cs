using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIscript : MonoBehaviour
{
    private bool IsCountering;
    private float CounterTime = 0.5f;
    private float RespawnTime = 2f;
    private bool IsAlive;
    private Animator anim;
    private CharacterController controller;
    private int ActionChance;
    public Vector3 SpawnPosition;
    private Quaternion SpawnRotation;

    private int CounterCount;

    void Start()
    {
        IsCountering = false;
        CounterCount = 0;
        IsAlive = true;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        anim.SetBool("Rektd", false);
        anim.ResetTrigger("Yeeted");
        SpawnPosition = this.transform.position;
        SpawnRotation = this.transform.rotation;
    }

    void Update()
    {
        if (IsAlive == false)
        {
            Invoke("Respawn", RespawnTime);
        }

        if (CounterCount >= 5 )
        {
            Invoke("ResetCounterCount", RespawnTime);
        }

        ActionChance = Random.Range(1,10);
    }

    void AICounter()
    {
        anim.SetTrigger("Counter");
        CounterCount = CounterCount + 1;
        IsCountering = true;
        NeedleTurn.TurnSpeed = NeedleTurn.TurnSpeed * (-1);
        Invoke("ResetCounter", CounterTime);
    }

    void AIJump()
    {
        anim.SetTrigger("Jumping");
        IsCountering= true;
        Invoke("ResetCounter", CounterTime);
        ActionChance = Random.Range(1,10);
    }

    void Respawn()
    {   
        anim.ResetTrigger("Yeeted");
        this.enabled = false;
        while (IsAlive == false)
        {
            this.enabled = true;
            anim.SetBool("Rektd", false);
            IsAlive = true;
            break;
        }
    }

    void ResetCounter()
    {
        IsCountering = false;
    }

    void ResetCounterCount()
    {
        CounterCount = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Needle"))
        {
            if (ActionChance <= 4)
            {
                AIJump();
                Debug.Log("Jumping");
            }        
            else if (ActionChance >= 6 && CounterCount < 5)
            {
                AICounter();
                Debug.Log("Countering");
            }

            if (IsCountering == false)
            {
                Debug.Log("Too Slow!");
                //anim.SetTrigger("Yeeted");
                //anim.SetBool("Rektd", true);
                if (IsAlive == true)
                {
                    Die();
                    Debug.Log("oh he dead");
                }
            }    
        }
	}

     void Die()
    {
        anim.SetTrigger("Yeeted");
        anim.SetBool("Rektd", true);
        IsAlive = false;
        DisplayStats.Lols = DisplayStats.Lols + 1;
        Invoke("Respawn", RespawnTime);
    }
}
