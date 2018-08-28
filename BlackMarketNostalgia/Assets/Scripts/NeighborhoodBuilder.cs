using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborhoodBuilder : MonoBehaviour {

    public Neighborhood[] neighborhoods;

    public float zoneFour;
    public float zoneThree;
    public float zoneTwo;
    public float zoneOne;
    private float distanceFromCorp;
    private Corporation corporation;

    private void Start()
    {
        corporation = FindObjectOfType<Corporation>();
        neighborhoods = FindObjectsOfType<Neighborhood>();
        AssignZone();
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
            neighborhood.SetColorByIncome();
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
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(95, 100) * 100f) / 100f;
            }
            else if (neighborhood.temperament == Temperament.Sypathetic)
            {
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(90, 95) * 100f) / 100f;
            }
            else if (neighborhood.temperament == Temperament.Contented)
            {
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(80, 90) * 100f) / 100f;
            }
            else if (neighborhood.temperament == Temperament.Neutral)
            {
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(50, 80) * 100f) / 100f;
            }
            else if (neighborhood.temperament == Temperament.Apathetic)
            {
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(30, 50) * 100f) / 100f;
            }
            else if (neighborhood.temperament == Temperament.Bitter)
            {
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(15, 30) * 100f) / 100f;
            }
            else
            {
                neighborhood.CorporateInfluence = Mathf.Round(Random.Range(5, 15) * 100f) / 100f;
            }
        }
    }
}