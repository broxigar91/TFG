using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vendor{

    public int id;
    public List<int> items;
    public List<int> quantities;
}

[System.Serializable]
public class VendorDB
{
    public List<Vendor> vendors;
}
