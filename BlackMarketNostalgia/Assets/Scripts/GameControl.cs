﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static int influenceToUnlock = 400;

    public static int playerInfluence = 0;

    private float tickTimer;

    private Neighborhood currentNeighborhood;
    private Neighborhood[] neighborhoods;
    private PlayerGUI playerGUI;
    private Player player;
    private TouchInput touch;

    public int PlayerInfluence
    {
        get { return playerInfluence; }
        set { playerInfluence = value; }
    }

    public int InfluenceToUnlock
    {
        get { return influenceToUnlock; }
        set { influenceToUnlock = value; }
    }

    public float TickTimer
    {
        get { return tickTimer; }
    }

    public Neighborhood CurrentNeighborhood
    {
        get { return currentNeighborhood; }
        set { currentNeighborhood = value; }
    }

    private void Start()
    {
        neighborhoods = FindObjectsOfType<Neighborhood>();
        player = FindObjectOfType<Player>();
        playerGUI = FindObjectOfType<PlayerGUI>();
        tickTimer = Calc.TickTime(player.Voice, player.Persistence);
    }

    private void Update()
    {
        tickTimer = Calc.TickTime(player.Voice, player.Persistence);
        player.Influence = PlayerInfluence;
        if (currentNeighborhood != null)
        {
            playerGUI.NeighborhoodInformation(currentNeighborhood);
        }
    }

    public void UnlockNeighborhood()
    {
        if (currentNeighborhood != null && currentNeighborhood.State == State.Inactive && currentNeighborhood.IsLocked && currentNeighborhood.IsUnlockable)
        {
            currentNeighborhood.IsLocked = false;
            influenceToUnlock += influenceToUnlock;
            currentNeighborhood.StartCoroutine("BeingInfluenced");
        }
    }
}
