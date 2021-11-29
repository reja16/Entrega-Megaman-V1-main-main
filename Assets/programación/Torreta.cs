using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    BoxCollider2D myCollider;
    [SerializeField] float fireRate;
    [SerializeField] private Transform ca�on;
    [SerializeField] GameObject BalaCa�on;
    [SerializeField] GameObject explosi�n;
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] GameObject Cuerpo;
    [SerializeField] public float vida;
    [SerializeField] GameManager gm;
    public float da�o = 1;
    int conteoDeDa�o;

    float nextFire = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("jugador en frente: " + DetectarJugadorDer());
        Debug.Log("jugador atr�s: " + DetectarJugadorIzq());
        dispararjugador();
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string bala = objeto.tag;

        if (objeto.tag == "bala")
        {
            conteoDeDa�o++;

            if (conteoDeDa�o == vida)
            {
                //bee_animator.SetTrigger("Destroy");
                muerte();
                Destroy(GetComponent<CircleCollider2D>());
                Destroy(gameObject, 1f);
                gm.contE();
            }

        }
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if(vida <= 0)
        {
            muerte();
        }
    }

    void muerte()
    {
        Instantiate(explosi�n, puntoA.transform.position, puntoA.rotation);
        Instantiate(Cuerpo, puntoB.transform.position, puntoB.rotation);
        Destroy(this.gameObject);
    }
    bool DetectarJugadorDer()
    {
        RaycastHit2D raycast_player = Physics2D.Raycast(myCollider.bounds.center, Vector2.right, myCollider.bounds.extents.y + 10f,
                                                                                                    LayerMask.GetMask("personaje"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.right * 10f, Color.red);
        return (raycast_player.collider != null);
    }
    bool DetectarJugadorIzq()
    {
        RaycastHit2D raycast_player = Physics2D.Raycast(myCollider.bounds.center, Vector2.left, myCollider.bounds.extents.y + 10f,
                                                                                                    LayerMask.GetMask("personaje"));

        Debug.DrawRay(myCollider.bounds.center, Vector2.left * 10f, Color.red);
        return (raycast_player.collider != null);
    }

    void dispararjugador()
    {
        if (DetectarJugadorIzq() && Time.time >= nextFire)
        {
            transform.localScale = new Vector2(5, 5);
            Instantiate(BalaCa�on, ca�on.transform.position, ca�on.rotation);
            nextFire = Time.time + fireRate;
        }
        if (DetectarJugadorDer() && Time.time >= nextFire)
        {
            transform.localScale = new Vector3(-5, 5);
            Instantiate(BalaCa�on, ca�on.transform.position, ca�on.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
