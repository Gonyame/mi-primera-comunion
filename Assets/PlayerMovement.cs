using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isDashing;
    private float dashTimeLeft;
    private float dashCooldownTimeLeft;

    [Header("Weapon Settings")]
    public WeaponController weaponController;
    public float weaponRange;
    public GameObject weaponHolder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashCooldownTimeLeft <= 0f)
        {
            isDashing = true;
            dashTimeLeft = dashDuration;
            dashCooldownTimeLeft = dashCooldown;
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

        //if the player presses the pickup button and is in range of a weapon pickup
        if (Input.GetKeyDown(KeyCode.E) && weaponController.PickedUp == false && Vector2.Distance(transform.position, weaponController.transform.position) < weaponRange)
        {
            //pick up the weapon
            weaponController.PickedUp = true;

            //set the weapon's parent to the player weaponholder
            weaponController.transform.SetParent(weaponHolder.transform);

            //move the weapon to the weaponholder
            weaponController.transform.position = weaponHolder.transform.position;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = isDashing ? moveDirection * dashSpeed : moveDirection * moveSpeed;
    }
}