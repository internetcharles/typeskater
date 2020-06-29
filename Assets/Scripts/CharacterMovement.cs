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



    public void Run()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.identity;

        //bool playerHasHorizontalSpeed = Mathf.Abs(MyRigidbody2D.velocity.x) > Mathf.Epsilon;
        //MyAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }
    public void Jump()
    {
        if (!MyCircleCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
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
