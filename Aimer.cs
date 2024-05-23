//Aiming script used for player
//Necessary for shooting function

//imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    //variables
    //serialize to show in inspector to edit
    [SerializeField] private float defDistanceRay = 100;
    //publics
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    //transforms
    Transform m_transform;

    //called when the scene is loaded, when everything is compiled but before the game realy 'starts'

    private void Awake()
    {
        //gets transform component of game object
        m_transform = GetComponent<Transform>();
    }

    void Aiming()
    {
        //calls line drawing method 
        Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
    }

    void Draw2DRay(Vector2 start, Vector2 end)
    {
        //sets the position of where the bullet is going to go
        m_lineRenderer.SetPosition(0, start);
        m_lineRenderer.SetPosition(1, end);
    }

    // Update is called once per frame
    void Update()
    {
        //aiming happens at any point
        Aiming();
    }
}
