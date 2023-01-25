using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform position1, position2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == position1.position)
        {
            nextPos = position2.position;
        }
        if (transform.position == position2.position)
        {
            nextPos = position1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}
