using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Temperament
{
    Outraged, Bitter, Apathetic, Neutral, Contented, Sypathetic, Loyal,
}

public enum IncomeClass
{
    Poverty, Lower, Middle, Upper, Ruling,
}

public enum State
{
    Inactive, Influenced, Event, 
}

public class Neighborhood : MonoBehaviour
{
    public Transform corporation;
    public SpriteRenderer lockSprite;
    public TextMesh indicatorText;

    public Temperament temperament;
    public IncomeClass incomeClass;

    public State state = State.Inactive;

    private string nieghborhoodName;

    private int zone;
    private int population;
    private int numberOfPossibleAllies;
    private int corporateInfluence;
    private int playerInfluence;
    private int playerInfluenceGained;
    private int otherInfluence;
    private int crimeRate;
    private int policePresence;

    private float neighborhoodSize;

    private bool isLocked;
    private bool isUnlockable;

    private GameControl gc;

    public IncomeClass IncomeClass
    {
        get { return incomeClass; }
        set { incomeClass = value; }
    }

    public Temperament Temperament
    {
        get { return temperament; }
        set { temperament = value; }
    }

    public State State
    {
        get { return state; }
        set { state = value; }
    }

    public int Zone
    {
        get { return zone; }
        set { zone = value; }
    }

    public float NeighborhoodSize
    {
        get { return neighborhoodSize; }
        set { neighborhoodSize = value; }
    }

    public int Population
    {
        get { return population; }
        set { population = value; }
    }

    public int CorporateInfluence
    {
        get { return corporateInfluence; }
        set { corporateInfluence = value; }
    }

    public int PlayerInfluenceGained
    {
        get { return playerInfluenceGained; }
    }

    public int CrimeRate
    {
        get { return crimeRate; }
        set { crimeRate = value; }
    }

    public int PolicePresence
    {
        get { return policePresence; }
        set { policePresence = value; }
    }

    public bool IsLocked
    {
        get { return isLocked; }
        set { isLocked = value; }
    }

    public bool IsUnlockable
    {
        get { return isUnlockable; }
        set { isUnlockable = value; }
    }

    private void Start()
    {
        gc = FindObjectOfType<GameControl>();
    }

    private void Update()
    {
        LockStatus();
    }

    public string NeighborhoodInfo()
    {
        string Information =
            "Name: " + this.name +
            "\nPopulation: " + population +
            "\nCorporate Inf: " + corporateInfluence + "%" +
            "\nTemperament: " + temperament.ToString() +
            "\nIncome Class: " + incomeClass.ToString() +
            "\nCrime Rate: " + crimeRate + "%" +
            "\nPolice Presence: " + policePresence + "%" +
            "\nPlayer Inf: " + playerInfluence + "%" +
            "\nLocked: " + isLocked +
            "\nUnlockable: " + isUnlockable;

        return Information;
    }

    private void LockStatus()
    {
        if (IsLocked && gc.PlayerInfluence >= gc.InfluenceToUnlock)
        {
            IsUnlockable = true;
            lockSprite.color = Color.green;
        }
        
        if (IsLocked && gc.PlayerInfluence < gc.InfluenceToUnlock)
        {
            IsUnlockable = false;
            lockSprite.color = Color.red;
        }
        
        if (!isLocked && state == State.Inactive)
        {
            IsUnlockable = false;
            lockSprite.enabled = false;
            state = State.Influenced;
            StartCoroutine("BeingInfluenced");
        }
    }

    public IEnumerator BeingInfluenced()
    {
        while (state == State.Influenced)
        {
            indicatorText.text = "INF!";
            gc.PlayerInfluence += 50;

            yield return new WaitForSeconds(1);

            indicatorText.text = "";

            yield return new WaitForSeconds(1);
        }
    }
}