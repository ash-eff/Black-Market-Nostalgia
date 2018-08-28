using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask neighborhoodMask;

    float deltaX, deltaY;

    RaycastHit2D hit;

    PlayerGUI playerGUI;
    Touch touch;
    Vector2 touchPos;

    private void Start()
    {
        playerGUI = FindObjectOfType<PlayerGUI>();
    }

    private void Update()
    {
        // if there is a touch
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            hit = Physics2D.Raycast(touchPos, Vector3.zero);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    if (hit.collider && hit.collider.tag == "Neighborhood")
                    {
                        playerGUI.NeighborhoodInformation(hit.transform.gameObject);
                    }

                    break;
            }

        }
    }
}
