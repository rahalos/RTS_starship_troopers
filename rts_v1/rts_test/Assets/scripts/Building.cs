using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingPacenet
{
    VALID,
    FIXED,
    INVALID
};

public class Building
{
    private BuildingData _data;
    private Transform _transform;
    private int _currentHealth;
    private BuildingPacenet _placement;
    private List<Material> _materials;
    private Building_manager _building_manager;






    public Building(BuildingData data)
    {   

        _data = data;
        _currentHealth = data.HP;
        _materials = new List<Material>();
        foreach (Material material in _transform.Find("base_pepl").GetComponent<Renderer>().materials)
        {
            _materials.Add(new Material(material));
        }


        GameObject g = GameObject.Instantiate(
            Resources.Load($"Prefabs/Building/{_data.Code}")
            ) as GameObject;
        _transform = g.transform;

        _building_manager = g.GetComponent<Building_manager>();
        _placement = BuildingPacenet.VALID;

        SetMaterials();


    }

    public void SetMaterials() { SetMaterials(_placement); }
    public void SetMaterials(BuildingPacenet placement)
    {
        List<Material> materials;
        if (placement == BuildingPacenet.VALID)
        {
            Material refMaterial = Resources.Load("Materials/Valid") as Material;
            materials = new List<Material>();
            for (int i = 0; i < _materials.Count; i ++ )
            {
                materials.Add(refMaterial);

            }

        }
        else if (placement == BuildingPacenet.INVALID)
        {
            Material refMaterial = Resources.Load("Materials/Valid") as Material;
            materials = new List<Material>();
            for (int i = 0; i < _materials.Count; i++)
            {
                materials.Add(refMaterial);

            }

        }
        else if (placement == BuildingPacenet.FIXED)
        {
            materials = _materials;

        }
        else
        {
            return;
        }
        _transform.Find("base_pepl").GetComponent<Renderer>().materials = materials.ToArray();

    }

    public void Place()
    {
        _placement = BuildingPacenet.FIXED;

        SetMaterials();

        _transform.GetComponent<BoxCollider>().isTrigger = false;

    }

    public void CheckValidPlacement()
    {
        if (_placement == BuildingPacenet.FIXED) return;

        _placement = _building_manager.CheckPlacement()
            ? BuildingPacenet.VALID
            : BuildingPacenet.INVALID;

    }

    public bool IsFixed { get => _placement == BuildingPacenet.FIXED; }

    public void SetPosition(Vector3 position)
    {
        _transform.position = position;

    }

    public string Code { get => _data.Code; }
    public Transform Transform { get => _transform; }
    public int HP { get => _currentHealth; set => _currentHealth = value; }
    public int MaxHP { get => _data.HP; }

    public int DataIndex
    {

        get
        {
            for (int i = 0; i < Globals.BUILDING_DATA.Length; i++)
            {
                if (Globals.BUILDING_DATA[i].Code == _data.Code)
                {
                    return i;
                }
            }
            return -1;
        }


    }

    public bool HasValidPlacement { get => _placement == BuildingPacenet.VALID; }


}