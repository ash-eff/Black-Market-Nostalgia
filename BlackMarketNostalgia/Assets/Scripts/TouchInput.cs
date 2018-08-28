using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask neighborhoodMask;

    RaycastHit2D hit;

    PlayerGUI playerGUI;
    Touch touch;
    Vector2 touchPos;

    private void Start()
    {
        playerGUI = FindObjectOfType<PlayerGUI>();
        
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
                playerGUI.NeighborhoodInformation(hit.transform.gameObject);
            }

            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {

                // TODO figure out why the z axis on the camera changes when moving with finger
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(new Vector3(-touchDeltaPosition.x * .10f, -touchDeltaPosition.y * .10f, 0));
            }
        }
    }
}