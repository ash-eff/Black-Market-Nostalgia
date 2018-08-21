using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string title;
    private string playerName;

    private float influence = 0f;
    private float chits = 0f;
    private float voice = 10f;
    private float persistence = 2f;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public float Influence
    {
        get { return influence; }
        set { influence = value; }
    }

    public float Chits
    {
        get { return chits; }
        set { chits = value; }
    }

    public float Voice
    {
        get { return voice; }
        set { voice = voice * value; }
    }

    public float Persistence
    {
        get { return persistence; }
        set { persistence = persistence * value; }
    }
}
