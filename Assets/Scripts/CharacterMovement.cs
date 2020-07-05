using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] private float jumpSpeed = 2f;

    private Rigidbody2D MyRigidbody2D;
    private CircleCollider2D MyCircleCollider2D;
    private Animator MyAnimator;
    private float gravityScaleAtStart;
    private GameObject[] rails;


    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        MyCircleCollider2D = GetComponent<CircleCollider2D>();
        gravityScaleAtStart = MyRigidbody2D.gravityScale;
        rails = GameObject.FindGameObjectsWithTag("Rail");

    }

    //void FixedUpdate()
    //{
    //    //NormalizeSlope();
    //}

    //void NormalizeSlope()
    //{
    //    if (MyCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")) ||
    //        MyCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ramp")))
    //    {
    //        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f);

    //        if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
    //        {
    //            MyRigidbody2D.velocity = new Vector2(MyRigidbody2D.velocity.x - hit.normal.x, MyRigidbody2D.velocity.y);
    //            Vector3 pos = transform.position;
    //            pos.y += -hit.normal.x * Mathf.Abs(MyRigidbody2D.velocity.x) * Time.deltaTime *
    //                     (MyRigidbody2D.velocity.x - hit.normal.x > 0 ? 1 : -1);
    //            transform.position = pos;
    //        }
    //    }
    //}

    public void Run()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.identity;

        //bool playerHasHorizontalSpeed = Mathf.Abs(MyRigidbody2D.velocity.x) > Mathf.Epsilon;
        //MyAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }
    public void Jump()
    {
        if (!MyCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")) && !MyCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ramp")))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            MyRigidbody2D.velocity += jumpVelocityToAdd;
        }

        if (MyCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ramp")) && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed * 1.5f);
            MyRigidbody2D.velocity += jumpVelocityToAdd;
        }
    }



    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }
}
