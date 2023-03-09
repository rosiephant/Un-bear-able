using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public int maxVal;
    public int currVal;

    public Stat(int curr, int max)
    {
        maxVal = max;
        currVal = curr;
    }

    internal void Subtract(int amount)
    {
        currVal -= amount;
    }

    internal void Add(int amount)
    {
        currVal += amount;

        if(currVal > maxVal)
        {
            currVal = maxVal;
        }
    }

    internal void SetToMax()
    {
        currVal = maxVal;
    }
}

public class Character : MonoBehaviour, IDamageable
{
    public Stat hp1;
    [SerializeField] StatusBar hpBar1;

    public bool isDead1;

    private void Start()
    {
        UpdateHPBar();
    }

    public void TakeDamage(int amount)
    {
        hp1.Subtract(amount);
        if(hp1.currVal <0)
        {
            isDead1 = true;
        }
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        hpBar1.Set(hp1.currVal, hp1.maxVal);
    }

    public void Heal(int amount)
    {
        hp1.Add(amount);
        UpdateHPBar();
    }

    public void FullHeal()
    {
        hp1.SetToMax();
        UpdateHPBar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Heal(10);
        }
    }

    public void CalculateDamage(ref int damage)
    {

    }

    public void ApplyDamage(int damage)
    {
        TakeDamage(damage);
    }

    public void CheckState()
    {

    }
}