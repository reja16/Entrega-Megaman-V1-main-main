using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bee : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] public int vida;
    [SerializeField] GameManager gm;
    int conteoDeDaño;

    Animator bee_animator;
    CircleCollider2D bee_collider;

    void Start()
    {
        bee_collider = GetComponent<CircleCollider2D>();
        bee_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string bala = objeto.tag;

        if (objeto.tag == "bala")
        {
            conteoDeDaño++;

            if (conteoDeDaño == vida)
            {
                bee_animator.SetTrigger("Destroy");
                Destroy(GetComponent<CircleCollider2D>());
                Destroy(gameObject, 1f);
                gm.contE();
            }
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.CompareTag("Player");
        
            

        
    }
}
