using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] public float daño;
    [SerializeField] public float tiempo;

    Rigidbody2D balacuerpo;
    BoxCollider2D balacolision;
    public GameObject Torreta;
    Animator animabala;
    // Start is called before the first frame update
    void Start()
    {
        Torreta = GameObject.Find("Torreta");
        animabala = GetComponent<Animator>();
        animabala.SetBool("Choque", false);
        balacuerpo = GetComponent<Rigidbody2D>();
        balacolision = GetComponent<BoxCollider2D>();
    }

    void tiempodevida()
    {
        Destroy(gameObject, tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        tiempodevida();
        movimiento();
    }
    void movimiento()
    {
        
        if (Torreta.transform.localScale.x == 5 && balacuerpo.velocity.x < 0.1f)//isquierda
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            balacuerpo.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(5, 5);
            //balacuerpo.AddForce(new Vector2(-speed, 0));
        }
        else if (Torreta.transform.localScale.x == -5 && balacuerpo.velocity.x > -0.1f) //derecha
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            balacuerpo.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-5, 5);
            //balacuerpo.AddForce(new Vector2 (speed,0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<megaman>().TomarDaño(daño);
        }
    }
}
