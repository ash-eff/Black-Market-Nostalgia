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

[ExecuteInEditMode]
public class Neighborhood : MonoBehaviour
{
    new Collider2D collider;
    public Transform corporation;
    public TextMesh temperamentText;
    public TextMesh influenceText;
    public string nieghborhoodName;
    // TODO hide in inspector
    private int zone;

    // TODO privatize variables after testing
    public int population;
    //public int numberOfPossibleAllies;
    private int minBasePop = 5000;
    private int maxBasePop = 6000;  
    
    public float corporateInfluence;
    //public float happiness;
    private float neighborhoodSize;
    
    public Temperament temperament;
    public IncomeClass incomeClass;

    private SpriteRenderer sr;
    //private List<Items> desiredList = new List<Items>();
    
    public bool isUnlocked;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        Setup();
    }

    private void Update()
    {
        temperamentText.text = temperament.ToString();
        influenceText.text = "Inf: " + corporateInfluence + "%";
    }

    private void Setup()
    {
        neighborhoodSize = collider.bounds.size.magnitude;
        population = Mathf.RoundToInt(Random.Range(minBasePop, maxBasePop) * neighborhoodSize / ((int)incomeClass + 1));      
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
