using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public GameObject mainCamera;
    private Animator animator;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    public bool IsAttacking(){
        return animator.GetCurrentAnimatorStateInfo(0).IsName("slash");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("slash");
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x == 0 && z == 0)
        {
            animator.SetBool("walking", false);
            return;
        }

        float forceX = 0;
        float forceZ = 0;

        if (x != 0)
        {
            forceX = (x > 0 ? 1 : -1) * speed;
        }
        if (z != 0)
        {
            // Rotate player to where the camera is pointing
            Vector3 rotation = mainCamera.transform.forward;
            rotation.y = 0f;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotation), Time.time * speed);

            forceZ = (z > 0 ? 1 : -1) * speed;
        }
        animator.SetBool("walking", true);
        body.AddRelativeForce(forceX, 0, forceZ, ForceMode.Impulse);
    }
}
