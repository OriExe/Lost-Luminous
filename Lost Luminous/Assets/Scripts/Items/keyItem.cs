using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyItem : MonoBehaviour
{
    private int amount = 1;
    private void Start()
    {
        
    }
    public void setKey(int number)
    {
        amount += number;
    }
    public int getKey()
    {
        return amount;
    }
}
