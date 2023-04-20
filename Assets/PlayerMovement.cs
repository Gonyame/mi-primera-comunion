using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
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

    //unity event
    public UnityEvent OnDash, OnDeadSpikes;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!morido)
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
    }

    private void FixedUpdate()
    {
        rb.velocity = isDashing ? moveDirection * dashSpeed : moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            muerteSpikes();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            muerteSpikes();
        }
    }

    private void muerteSpikes()
    {
        if (!isDashing)
        {
            morido = true;
            moveDirection= Vector3.zero;
            Debug.Log("Moriste por spikes");
            anim.SetBool("dead", morido);
            OnDeadSpikes.Invoke();
            Invoke("revivir", 4f);
        }
    }

    private void revivir()
    {
        morido = false;
        anim.SetBool("dead", morido);
        transform.position = spawnpoint.transform.position;
    }
}