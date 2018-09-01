using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborhoodBuilder : MonoBehaviour {

    public Neighborhood[] neighborhoods;

    public float zoneFour;
    public float zoneThree;
    public float zoneTwo;
    public float zoneOne;
    public int minBasePop = 5000;
    public int maxBasePop = 6000;
    private float distanceFromCorp;
    private Corporation corporation;

    private void Start()
    {
        corporation = FindObjectOfType<Corporation>();
        neighborhoods = FindObjectsOfType<Neighborhood>();
        AssignLocked();
        AssignZone();
        AssignSize();
    }

    private void AssignLocked()
    {
        int randomIndex = Random.Range(0, neighborhoods.Length - 1);
        for(int i = neighborhoods.Length - 1; i > -1; i--)
        {
            if(i == randomIndex)
            {
                neighborhoods[i].IsLocked = false;
            }
            else
            {
                neighborhoods[i].IsLocked = true;
                neighborhoods[i].IsUnlockable = false;
            }
        }
    }

    private void AssignZone()
    {
        foreach(Neighborhood neighborhood in neighborhoods)
        {
            distanceFromCorp = (corporation.transform.position - neighborhood.transform.position).magnitude;

            if(distanceFromCorp < zoneFour)
            {
                neighborhood.Zone = 4;
            }
            else if (distanceFromCorp < zoneThree && distanceFromCorp > zoneFour)
            {
                neighborhood.Zone = 3;
            }
            else if (distanceFromCorp < zoneTwo && distanceFromCorp > zoneThree)
            {
                neighborhood.Zone = 2;
            }
            else if (distanceFromCorp < zoneOne && distanceFromCorp > zoneTwo)
            {
                neighborhood.Zone = 1;
            }
            else
            {
                neighborhood.Zone = 0;
            }
        }

        AssignIncomeClass();
    }

    private void AssignIncomeClass()
    {
        foreach (Neighborhood neighborhood in neighborhoods)
        {
            int zoneChance = Random.Range(1, 100);

            if(neighborhood.Zone == 4)
            {
                if(zoneChance < 41)
                {
                    neighborhood.IncomeClass = IncomeClass.Ruling;
                }
                else if(zoneChance > 40 && zoneChance < 86)
                {
                    neighborhood.IncomeClass = IncomeClass.Upper;
                }
                else if(zoneChance > 85 && zoneChance < 91)
                {
                    neighborhood.IncomeClass = IncomeClass.Middle;
                }
                else if(zoneChance > 90 && zoneChance < 96)
                {
                    neighborhood.IncomeClass = IncomeClass.Lower;
                }
                else
                {
                    neighborhood.IncomeClass = IncomeClass.Poverty;
                }
            }
            else if (neighborhood.Zone == 3)
            {
                if (zoneChance < 41)
                {
                    neighborhood.IncomeClass = IncomeClass.Upper;
                }
                else if (zoneChance > 40 && zoneChance < 76)
                {
                    neighborhood.IncomeClass = IncomeClass.Middle;
                }
                else if (zoneChance > 75 && zoneChance < 91)
                {
                    neighborhood.IncomeClass = IncomeClass.Lower;
                }
                else
                {
                    neighborhood.IncomeClass = IncomeClass.Poverty;
                }
            }
            else if (neighborhood.Zone == 2)
            {
                if (zoneChance < 34)
                {
                    neighborhood.IncomeClass = IncomeClass.Middle;
                }
                else if (zoneChance > 33 && zoneChance < 66)
                {
                    neighborhood.IncomeClass = IncomeClass.Lower;
                }
                else
                {
                    neighborhood.IncomeClass = IncomeClass.Poverty;
                }
            }
            else if (neighborhood.Zone == 1)
            {
                if (zoneChance < 41)
                {
                    neighborhood.IncomeClass = IncomeClass.Lower;
                }
                else
                {
                    neighborhood.IncomeClass = IncomeClass.Poverty;
                }
            }
            else
            {
                neighborhood.IncomeClass = IncomeClass.Poverty;
            }
        }

        AssignTemperament();
    }

    private void AssignTemperament()
    {
        foreach (Neighborhood neighborhood in neighborhoods)
        {
            int incomeChance = Random.Range(1, 100);

            if (neighborhood.incomeClass == IncomeClass.Ruling)
            {
                if (incomeChance < 71)
                {
                    neighborhood.temperament = Temperament.Loyal;
                }
                else if (incomeChance > 70)
                {
                    neighborhood.temperament = Temperament.Sypathetic;
                }
            }
            else if (neighborhood.incomeClass == IncomeClass.Upper)
            {
                if (incomeChance < 51)
                {
                    neighborhood.temperament = Temperament.Sypathetic;
                }
                else if (incomeChance > 50 && incomeChance < 76)
                {
                    neighborhood.temperament = Temperament.Loyal;
                }
                else
                {
                    neighborhood.temperament = Temperament.Contented;
                }
            }
            else if (neighborhood.incomeClass == IncomeClass.Middle)
            {
                if (incomeChance < 36)
                {
                    neighborhood.temperament = Temperament.Contented;
                }
                else if (incomeChance > 35 && incomeChance < 61)
                {
                    neighborhood.temperament = Temperament.Neutral;
                }
                else if (incomeChance > 60 && incomeChance < 86)
                {
                    neighborhood.temperament = Temperament.Apathetic;
                }
                else if (incomeChance > 85 && incomeChance < 96)
                {
                    neighborhood.temperament = Temperament.Sypathetic;
                }
                else
                {
                    neighborhood.temperament = Temperament.Loyal;
                }
            }
            else if (neighborhood.incomeClass == IncomeClass.Lower)
            {
                if (incomeChance < 36)
                {
                    neighborhood.temperament = Temperament.Bitter;
                }
                else if (incomeChance > 35 && incomeChance < 61)
                {
                    neighborhood.temperament = Temperament.Neutral;
                }
                else if (incomeChance > 60 && incomeChance < 81)
                {
                    neighborhood.temperament = Temperament.Outraged;
                }
                else if (incomeChance > 80 && incomeChance < 91)
                {
                    neighborhood.temperament = Temperament.Apathetic;
                }
                else if (incomeChance > 90 && incomeChance < 96)
                {
                    neighborhood.temperament = Temperament.Contented;
                }
                else if (incomeChance > 95 && incomeChance < 99)
                {
                    neighborhood.temperament = Temperament.Apathetic;
                }
                else
                {
                    neighborhood.temperament = Temperament.Loyal;
                }
            }
            else
            {
                if (incomeChance < 51)
                {
                    neighborhood.temperament = Temperament.Outraged;
                }
                else if (incomeChance > 50 && incomeChance < 81)
                {
                    neighborhood.temperament = Temperament.Bitter;
                }
                else if (incomeChance > 80 && incomeChance < 91)
                {
                    neighborhood.temperament = Temperament.Apathetic;
                }
                else if (incomeChance > 90 && incomeChance < 96)
                {
                    neighborhood.temperament = Temperament.Neutral;
                }
                else if (incomeChance > 95 && incomeChance < 98)
                {
                    neighborhood.temperament = Temperament.Contented;
                }
                else if (incomeChance > 97 && incomeChance < 100)
                {
                    neighborhood.temperament = Temperament.Sypathetic;
                }
                else
                {
                    neighborhood.temperament = Temperament.Loyal;
                }
            }
        }

        AssignCorporateInfluence();
    }

    private void AssignCorporateInfluence()
    {
        foreach (Neighborhood neighborhood in neighborhoods)
        {
            if (neighborhood.temperament == Temperament.Loyal)
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(95, 100));
            }
            else if (neighborhood.temperament == Temperament.Sypathetic)
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(90, 95));
            }
            else if (neighborhood.temperament == Temperament.Contented)
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(80, 90));
            }
            else if (neighborhood.temperament == Temperament.Neutral)
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(50, 80));
            }
            else if (neighborhood.temperament == Temperament.Apathetic)
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(30, 50));
            }
            else if (neighborhood.temperament == Temperament.Bitter)
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(15, 30));
            }
            else
            {
                neighborhood.CorporateInfluence = Mathf.RoundToInt(Random.Range(5, 15));
            }
        }

        AssignCrimeRate();
    }

    private void AssignCrimeRate()
    {
        foreach (Neighborhood neighborhood in neighborhoods)
        {
            if (neighborhood.incomeClass == IncomeClass.Ruling)
            {
                neighborhood.CrimeRate = Mathf.RoundToInt(Random.Range(2, 5));
                neighborhood.PolicePresence = Mathf.RoundToInt(Random.Range(40, 50));
            }
            else if (neighborhood.incomeClass == IncomeClass.Upper)
            {
                neighborhood.CrimeRate = Mathf.RoundToInt(Random.Range(5, 11));
                neighborhood.PolicePresence = Mathf.RoundToInt(Random.Range(30, 40));
            }
            else if (neighborhood.incomeClass == IncomeClass.Middle)
            {
                neighborhood.CrimeRate = Mathf.RoundToInt(Random.Range(12, 28));
                neighborhood.PolicePresence = Mathf.RoundToInt(Random.Range(20, 30));
            }
            else if (neighborhood.incomeClass == IncomeClass.Lower)
            {
                neighborhood.CrimeRate = Mathf.RoundToInt(Random.Range(28, 39));
                neighborhood.PolicePresence = Mathf.RoundToInt(Random.Range(10, 30));
            }
            else
            {
                neighborhood.CrimeRate = Mathf.RoundToInt(Random.Range(40, 52));
                neighborhood.PolicePresence = Mathf.RoundToInt(Random.Range(5, 30));
            }
        }
    }

    private void AssignSize()
    {
        foreach(Neighborhood neighborhood in neighborhoods)
        {
            Collider2D collider = neighborhood.GetComponent<Collider2D>();
            neighborhood.NeighborhoodSize = collider.bounds.size.magnitude;
        }

        AssignPopulation();
    }

    private void AssignPopulation()
    {
        foreach(Neighborhood neighborhood in neighborhoods)
        {
            neighborhood.Population = Mathf.RoundToInt(Random.Range(minBasePop, maxBasePop) * neighborhood.NeighborhoodSize / (int)neighborhood.IncomeClass + 1 );
            neighborhood.PopulationInfluencedByCorp = Mathf.RoundToInt(neighborhood.Population * (neighborhood.CorporateInfluence * .01f));
            neighborhood.PopulationInfluencedByNone = neighborhood.Population - neighborhood.PopulationInfluencedByCorp;
            neighborhood.PopulationInfluencedByPlayer = 0;
        }     
    }
}