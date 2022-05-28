using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PipoulpeGrappler : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;
    public SpringJoint2D springJoint;
    Transform tf;
    Rigidbody2D rb;

    //private Vector2[] positions = new Vector2[10];
    
    public GameObject cursor;
    Transform cursorTf;

    [SerializeField] float boostForce;
    public float aboveY;
    public float speedForSpring;


    private int indexPoint = 0;
    private int numberOfPoints;
    private List<Vector2> positions = new List<Vector2>();


    // Start is called before the first frame update
    void Start()
    {
        tf = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();

        cursorTf = cursor.GetComponent<Transform>();

        GameObject[] GrapplingPoints = GameObject.FindGameObjectsWithTag("GrapplingPoint");
        numberOfPoints = GrapplingPoints.Length;

        if (numberOfPoints>0)
        {
            foreach(GameObject Point in GrapplingPoints)
            {
                positions.Add(Point.transform.position);
            }

            Debug.Log(numberOfPoints);
            Debug.Log(positions[0]);
            Debug.Log("index point = " + indexPoint);
            cursorTf.position = positions[indexPoint] + new Vector2(0, aboveY);
        }

        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
        springJoint.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer.enabled == true)
        {
            lineRenderer.SetPosition(0, tf.position);
            if (rb.velocity.x > 0)
            {
                rb.AddForce(new Vector2(boostForce, 0),ForceMode2D.Force);
            }
            else if (rb.velocity.x<0)
            {
                rb.AddForce(new Vector2(-boostForce, 0), ForceMode2D.Force);
            }
        }

    }


    public void Grappling(InputAction.CallbackContext context)
    {

        Debug.Log("InputAction Grappling");

        if (numberOfPoints>0)
        {

            lineRenderer.SetPosition(0, tf.position);
            lineRenderer.SetPosition(1, positions[indexPoint]);

            distanceJoint.connectedAnchor = positions[indexPoint];
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
        }
    }

    public void ReleaseGrappling(InputAction.CallbackContext context)
    {
        if (numberOfPoints>0)
        {
            Debug.Log("InputAction ReleaseGrappling");

            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
        }
    }


    public void Spring(InputAction.CallbackContext context)
    {
        if (numberOfPoints>0)
        {
            Debug.Log("InputAction Spring");

            distanceJoint.enabled = false;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, tf.position);
            lineRenderer.SetPosition(1, positions[indexPoint]);

            springJoint.connectedAnchor = positions[indexPoint];
            springJoint.distance = (tf.position - cursorTf.position).magnitude / 4;
            springJoint.frequency = speedForSpring;
            springJoint.enabled = true;
        }
    }

    public void ReleaseSpring(InputAction.CallbackContext context)
    {
        if (numberOfPoints>0)
        {
            Debug.Log("InputAction ReleaseSpring");

            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
            springJoint.enabled = false;
        }
    }


    public void ChangeTarget(InputAction.CallbackContext context)
    {
        if (numberOfPoints>0)
        {
            if (indexPoint + 1 == numberOfPoints)
            {
                indexPoint = 0;
            }
            else
            {
                indexPoint += 1;
            }

            Debug.Log("inputaction; index point = " + indexPoint + " and positions[indexPoint] = " + positions[indexPoint]);

            cursorTf.position = positions[indexPoint] + new Vector2(0,aboveY);
        
            Debug.Log("finished changeTarget");
        }
    }
}
