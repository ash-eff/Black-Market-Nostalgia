using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Temperament
{
    Outraged, Bitter, Apathetic, Neutral, Contented, Sypathetic, Loyal,
}

public enum IncomeClass
{
    Poverty, Lower, Middle, Upper, Ruling,
}

public class Neighborhood : MonoBehaviour
{
    new Collider2D collider;
    public Transform corporation;
    public TextMesh temperamentText;
    public TextMesh influenceText;

    public Temperament temperament;
    public IncomeClass incomeClass;

    private string nieghborhoodName;
    
    private int zone;
    private int population;
    private int numberOfPossibleAllies;
    private int minBasePop = 5000;
    private int maxBasePop = 6000;  
    
    private float corporateInfluence;
    private float playerInfluence;
    private float otherInfluence;
    private float crimeRate;
    private float policePresence;
    private float neighborhoodSize;

    private SpriteRenderer sr;
    
    private bool isUnlocked;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        neighborhoodSize = collider.bounds.size.magnitude;
        population = Mathf.RoundToInt(Random.Range(minBasePop, maxBasePop) * neighborhoodSize / ((int)incomeClass + 1));
    }

    private void Update()
    {
        temperamentText.text = temperament.ToString();
        influenceText.text = "Inf: " + corporateInfluence + "%";
    }

    public string NeighborhoodInfo()
    {
        string Information = "Name: " + this.name + "\nPopulation: " +
            population + "\nCorporate Inf: " + corporateInfluence +
            "\nTemperament: " + temperament.ToString() + "\nIncome Class: " +
            incomeClass.ToString();
        return Information;
    }

    public IncomeClass IncomeClass
    {
        get { return IncomeClass; }
        set { incomeClass = value; }
    }

    public Temperament Temperament
    {
        get { return Temperament; }
        set { temperament = value; }
    }

    public int Zone
    {
        get { return zone; }
        set { zone = value; }
    }

    public float CorporateInfluence
    {
        get { return corporateInfluence; }
        set { corporateInfluence = value; }
    }





    // TODO for testing only. Remove
    public void SetColorByIncome()
    {
        if (incomeClass == IncomeClass.Ruling)
        {
            sr.color = Color.yellow;
        }
        else if (incomeClass == IncomeClass.Upper)
        {
            sr.color = Color.blue;
        }
        else if (incomeClass == IncomeClass.Middle)
        {
            sr.color = Color.green;
        }
        else if (incomeClass == IncomeClass.Lower)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.grey;
        }
    }
}
