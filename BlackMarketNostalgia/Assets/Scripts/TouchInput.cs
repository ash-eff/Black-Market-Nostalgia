using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask neighborhoodMask;
    RaycastHit2D hit;
    GameControl gameControl;

    Touch touch;
    Vector2 touchPos;

    private void Start()
    {
        gameControl = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // if there is a touch
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            hit = Physics2D.Raycast(touchPos, Vector3.zero, neighborhoodMask);

            if (hit && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                gameControl.CurrentNeighborhood = hit.transform.GetComponent<Neighborhood>();
            }

            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(new Vector3(-touchDeltaPosition.x * .05f, -touchDeltaPosition.y * .05f, 0));
            }
        }
    }
}