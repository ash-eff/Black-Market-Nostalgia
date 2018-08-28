using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {

    public Text neighborhoodInfoText;

    public void NeighborhoodInformation(GameObject neighborhood)
    {
        neighborhoodInfoText.text = neighborhood.GetComponent<Neighborhood>().NeighborhoodInfo();
    }

}
