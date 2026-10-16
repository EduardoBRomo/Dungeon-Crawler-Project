using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 1.25f;
    private Rigidbody2D rb;
    private SpriteRenderer sR;
    private Animator anim;

    [Header("Movimiento")]
    private bool isWalking;

    void Awake()
    {
        GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>();
        sR = GetComponent<SpriteRenderer>();
        GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); //GetAxisRaw, a diferencia del que no tiene Raw, hace que el movimiento se más rígido, haciendo al jugador más controlable
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direccion = new Vector2 (x, y) * velocidad;
        rb.linearVelocity = direccion;

        //A partir de aquí se gestionan las animaciones, isWalking cambia a la animación de movimiento, mientras que flipX se encarga de la dirección
        anim.SetBool("isWalking", isWalking);

        if (x < 0)
        {
            sR.flipX = true;
            isWalking = true;

        }
        else if (x > 0)
        {
            sR.flipX = false;
            isWalking = true;
        }
        else if (x == 0 && y == 0)
        {
            isWalking = false;
        }

        if (y != 0)
        {
            isWalking = true;
        }
    }
}