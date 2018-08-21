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

    public void Build()
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
                neighborhood.zone = 4;
            }
            else if (distanceFromCorp < zoneThree && distanceFromCorp > zoneFour)
            {
                neighborhood.zone = 3;
            }
            else if (distanceFromCorp < zoneTwo && distanceFromCorp > zoneThree)
            {
                neighborhood.zone = 2;
            }
            else if (distanceFromCorp < zoneOne && distanceFromCorp > zoneTwo)
            {
                neighborhood.zone = 1;
            }
            else
            {
                neighborhood.zone = 0;
            }
        }
    }

    public void AssignIncomeClass()
    {
        foreach (Neighborhood neighborhood in neighborhoods)
        {
            int zoneChance = Random.Range(1, 100);

            if(neighborhood.zone == 4)
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
            else if (neighborhood.zone == 3)
            {
                if (zoneChance < 41)
                {
                    neighborhood.IncomeClass = IncomeClass.Upper;
                }
                else if (zoneChance > 40 && zoneChance < 81)
                {
                    neighborhood.IncomeClass = IncomeClass.Middle;
                }
                else if (zoneChance > 80 && zoneChance < 91)
                {
                    neighborhood.IncomeClass = IncomeClass.Lower;
                }
                else
                {
                    neighborhood.IncomeClass = IncomeClass.Poverty;
                }
            }
            else if (neighborhood.zone == 2)
            {
                if (zoneChance < 51)
                {
                    neighborhood.IncomeClass = IncomeClass.Middle;
                }
                else if (zoneChance > 50 && zoneChance < 76)
                {
                    neighborhood.IncomeClass = IncomeClass.Lower;
                }
                else
                {
                    neighborhood.IncomeClass = IncomeClass.Poverty;
                }
            }
            else if (neighborhood.zone == 1)
            {
                if (zoneChance < 51)
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(corporation.transform.position, zoneFour);
        Gizmos.DrawWireSphere(corporation.transform.position, zoneThree);
        Gizmos.DrawWireSphere(corporation.transform.position, zoneTwo);
        Gizmos.DrawWireSphere(corporation.transform.position, zoneOne);
    }

    // TODO for testing only, remove
    public void ResetIncomeClass()
    {
        foreach(Neighborhood neighborhood in neighborhoods)
        {
            neighborhood.incomeClass = IncomeClass.Lower;
            neighborhood.SetColorByIncome();
            neighborhoods = null;
        }
    }
}
