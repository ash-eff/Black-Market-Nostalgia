using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string playerName;
    public int val;
    
    public static int influence = 0;
    private float chits;
    private float voice = 10f;
    private float persistence = 2f;

    private void Update()
    {
        val = influence;
    }

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public int Influence
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
