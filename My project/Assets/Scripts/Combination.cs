using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

[Serializable]
public class Combination
{   
    public string atmostphere = null;
    public string gravity = null;
    public string temperature = null;
    public string water = null;

    public void UpdateAtmostphere(string newValue) {
        atmostphere = newValue;
    }

    public void UpdateGravity(string newValue) {
        gravity = newValue;
    }

    public void UpdateTemp(string newValue) {
        temperature = newValue;
    }

    public void UpdateWater(string newValue) {
        water = newValue;
    }

}
