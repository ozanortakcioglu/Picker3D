using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float friction = 0.7f;
    public UIController canvas;
    public ObjectsController objectsController;

    Rigidbody rb;

    bool movable = false;
    public bool colliderControl = true;
    bool wait = false;
    bool inTunnel = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!wait)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                movable = true;
            }
        }
        if (movable)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "End")
        {
            if (colliderControl)
            {
                colliderControl = false;
                movable = false;
                inTunnel = false;
                canvas.CurrentLevel += +1;
                canvas.Coins();
            }
        }
        if (other.tag == "1")
        {
            if(colliderControl)
            {
                colliderControl = false;
                movable = false;
                StartCoroutine(Wait(2f));
                canvas.CheckPoint1();
            }

        }
        if (other.tag == "2")
        {
            if (colliderControl)
            {
                colliderControl = false;
                movable = false;
                StartCoroutine(Wait(2f));
                canvas.CheckPoint2();
            }
        }
        if (other.tag == "collidercontrol")
            colliderControl = true;
        if (other.tag == "dama")
        {
            inTunnel = true;
        }
    }

    void Move()
    {
        if(inTunnel)
            rb.velocity = new Vector3(0, 0, 2000f) * Time.deltaTime;
        else
            rb.velocity = new Vector3(0, 0, 800f) * Time.deltaTime;

        rb.velocity += new Vector3(1f, 0, 0) * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity *= friction;
    }
    private void LateUpdate()
    {
        if(inTunnel)
            Camera.main.transform.position = new Vector3(0, 6, transform.position.z - 12);
        else
            Camera.main.transform.position = new Vector3(0, 8, transform.position.z - 12);
    }

    IEnumerator Wait(float seconds)
    {
        wait = true;
        yield return new WaitForSeconds(seconds/2);
        objectsController.SetActiveFalse();
        yield return new WaitForSeconds(seconds / 2);
        movable = true;
        wait = false;
        colliderControl = true;
        yield return null;
    }
}
