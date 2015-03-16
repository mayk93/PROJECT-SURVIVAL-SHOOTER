using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 500.0f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h,v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h,0f,v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(camRay,out floorHit, camRayLength,floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newQuaternion = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newQuaternion);
        }
    }

    void Animating(float h, float v)
    {
        //print(h);
        //print(v);
        //print((h != 0f) || (v != 0f));
        bool walking = ((h != 0f) || (v != 0f));
        //bool walking = true;
        anim.SetBool("IsWalking", walking);
    }
}
