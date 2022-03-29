using System.Collections.Generic;


public class BildingData
{
    private string _code;
    private int _healtpoints;


    public BildingData(string code, int healthpoints)
    {
        _code = code;
        _healtpoints = healthpoints;


    }



    public string Code { get => _code; }
    public int HP { get => _healtpoints; }


}