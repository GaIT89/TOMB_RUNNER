using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody rb;
    private Collider col;

    public LayerMask groundLayer;
    public float runSpeed;
    public float moveSpeed;
    public float jumpVelocity;

   
    private int isRunAnimID;
    private int isHitAnimID;

    //private int isJumpAnimID;
    //private int jumpAnimID;

    //private bool isRunning;
    //private bool isJumpPress;
  

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        //isJumpAnimID = Animator.StringToHash("isJump");
        isRunAnimID = Animator.StringToHash("isRun");
        isHitAnimID = Animator.StringToHash("isHit");
        //jumpAnimID = Animator.StringToHash("Jump");
    }

    private void Update()
    {
        PlayerInputCheck();
    }

    private void FixedUpdate()
    {
        UpdateGameState();
    }
    void UpdateGameState()
    {
        if (GameManager.Instance.IsGameStart())
        {
            RunForwad();
            Move();
            Jump();
        }
    }

    void PlayerInputCheck()
    {
        // isJumpPress = (Input.GetKeyDown(KeyCode.Space));
    }
    void RunForwad()
    {
        rb.velocity = (Vector3.forward) * runSpeed;
        if (IsGrounded())
        {
            Anim.SetBool(isRunAnimID, true);
        }
    }

    void Move()
    {
        Vector3 playervelocity;
        playervelocity = rb.velocity;
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3 (-moveSpeed, playervelocity.y , playervelocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(moveSpeed, playervelocity.y, playervelocity.z);
        }
    }

    void Jump()
    {   /* TODO : Jump Function Not Work
         * 
        isJumping = Anim.GetBool(isJumpAnimID);
        if (isJumpPress && IsGrounded())
        {
            rb.velocity = Vector3.up * jumpVelocity;
            Anim.SetBool(isJumpAnimID, true);
        }
        else if (!isJumpPress && isJumping)
        {
            Anim.SetBool(isJumpAnimID, false);
        }
        */
    }

    bool IsGrounded()
    {
        return Physics.Raycast(col.bounds.center, Vector3.down, out RaycastHit hit, col.bounds.extents.y + 0.1f, groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mummy"))
        {
            //Debug.Log("Hit Mummy");
            Anim.SetTrigger(isHitAnimID);
            AudioManager.instance.Play("HitMummySound");
            AudioManager.instance.Play("HitMummySound2");

            AudioManager.instance.Play("PlayerHit");

            AudioManager.instance.Stop("GameMusicBackGround");
            AudioManager.instance.Stop("RunSound");

            GameManager.Instance.GameEnd();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Debug.Log("Collect Gem");

            AudioManager.instance.Play("PickUpSound");

            Destroy(other.gameObject);

            GameManager.Instance.AddPlayerScore();
        }
    }
}
