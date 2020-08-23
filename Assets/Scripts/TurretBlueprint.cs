using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Will show up in the inspector or less Unity won't know
[RequireComponent(typeof(Turret))]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    public Turret turret;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}