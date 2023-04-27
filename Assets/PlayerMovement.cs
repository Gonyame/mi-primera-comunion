using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    [SerializeField] private Animator anim;
    [SerializeField] private GameObject spawnpoint;
    private bool morido;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isDashing;
    private float dashTimeLeft;
    private float dashCooldownTimeLeft;
    public bool atrapao;
    public int forcejeo;

    //unity event
    public UnityEvent OnDash, OnDeadSpikes;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!morido && !atrapao)
        {
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            anim.SetBool("Moving", moveDirection != Vector2.zero);

            if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashCooldownTimeLeft <= 0f)
            {
                isDashing = true;
                dashTimeLeft = dashDuration;
                dashCooldownTimeLeft = dashCooldown;
                anim.SetTrigger("dash");
                OnDash.Invoke();
            }

            if (isDashing)
            {
                dashTimeLeft -= Time.deltaTime;
                if (dashTimeLeft <= 0f)
                {
                    isDashing = false;
                }
            }

            if (dashCooldownTimeLeft > 0f)
            {
                dashCooldownTimeLeft -= Time.deltaTime;
            }

            //flip the character
            if (moveDirection.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moveDirection.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }


        }
        if (!morido && atrapao)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (forcejeo > 0)
                {
                    forcejeo--;
                }
                else
                {
                    safarse();
                }

            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = isDashing ? moveDirection * dashSpeed : moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes") && isDashing==false)
        {
            muerteSpikes();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes") && isDashing == false)
        {
            muerteSpikes();
        }
        if (collision.gameObject.CompareTag("cuchillas"))
        {
            muerteSpikes();
        }
    }

    private void muerteSpikes()
    {
        
            morido = true;
            moveDirection= Vector3.zero;
            Debug.Log("Moriste por spikes");
            anim.SetBool("dead", morido);
            OnDeadSpikes.Invoke();
            Invoke("revivir", 4f);
        
    }

    private void revivir()
    {
        morido = false;
        anim.SetBool("dead", morido);
        transform.position = spawnpoint.transform.position;
    }
    public void atrapado()
    {
        atrapao = true;
        anim.SetBool("Moving", false);
        moveSpeed = 0;
        forcejeo = 3;

    }
    public void safarse()
    {
      //  PlayerController.instance.atrapado();
       moveSpeed = 5f;
        atrapao = false;
    }
}