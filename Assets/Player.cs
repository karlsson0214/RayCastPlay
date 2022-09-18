using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;

        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.left * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector2.down * speed;
        }
        else
        {
            // stop
            rb.velocity = Vector2.zero;
        }
        // distance between boxcast and box collider 2d
        float deltaY = 0.02f;
        float boxCastHight = 0.02f;
        float boxCastWidth = boxCollider2D.size.x;
        Vector2 origin = boxCollider2D.transform.position;
        // center of box cast
        origin = new Vector2(origin.x, origin.y - boxCollider2D.size.y * 0.5f - deltaY - boxCastHight * 0.5f);
        // width and height of box cast
        Vector2 size = new Vector2(boxCastWidth, boxCastHight);
        Vector2 direction = Vector2.down;
        float angle = 0;
        // do not extend the box down
        float distance = 0;
        RaycastHit2D hit = Physics2D.BoxCast(origin, size, angle, direction, distance);
        Color color = Color.green;
        if (hit.collider != null)
        {
            // box cast hit something
            color = Color.red;
            Debug.Log("hit");
        }
        // corners in box cast
        Vector2 cornerUpperLeft = origin + new Vector2(-boxCastWidth, boxCastHight) * 0.5f;
        Vector2 cornerUpperRight = origin + new Vector2(boxCastWidth, boxCastHight) * 0.5f;
        Vector2 cornerLowerLeft = origin + new Vector2(-boxCastWidth, -boxCastHight) * 0.5f;
        Vector2 cornerLowerRight = origin + new Vector2(boxCastWidth, -boxCastHight) * 0.5f;

        // draw cast box
        Debug.DrawLine(cornerUpperLeft, cornerUpperRight, color);
        Debug.DrawLine(cornerLowerLeft, cornerLowerRight, color);
        Debug.DrawLine(cornerUpperLeft, cornerLowerLeft, color);
        Debug.DrawLine(cornerUpperRight, cornerLowerRight, color);





    }
}
