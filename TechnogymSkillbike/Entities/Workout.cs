using System;
using System.Collections.Generic;

public class Workout
{
    public Data data { get; set; }
    public string token { get; set; }
    public string version { get; set; }
    public int expireIn { get; set; }
}

public class Data
{
    public Analitics analitics { get; set; }
    public string equipmentType { get; set; }
    public string cardioLogId { get; set; }
    public int favorite { get; set; }
    public string name { get; set; }
    public string date { get; set; }
    public string target { get; set; }
    public int nEser { get; set; }
    public int nAttr { get; set; }
    public string physicalActivityId { get; set; }
    public string physicalActivityName { get; set; }
    public List<DataItem> data { get; set; }
}

public class Analitics
{
    public List<Descriptor> descriptor { get; set; }
    public List<Sample> samples { get; set; }
}

public class Descriptor
{
    public int i { get; set; }
    public Property pr { get; set; }
}

public class Property
{
    public string name { get; set; }
    public string um { get; set; }
}

public class Sample
{
    public List<decimal> vs { get; set; }
    public int t { get; set; }
}

public class DataItem
{
    public string property { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public string uM { get; set; }
    public double rawValue { get; set; }
}
