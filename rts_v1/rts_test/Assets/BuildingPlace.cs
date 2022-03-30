using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    private Building _placedBuilding = null;

    private Ray _ray;
    private RaycastHit _raycastHit;
    private Vector3 _lastPlacementPosition;

    void Start()
    {

        _PreparePlacedBuilding(0);

    }



    void Update()
    {
        if (_placedBuilding != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _CancelPlacedBuing();

                return;
            }


            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(
                _ray,
                out _raycastHit,
                1000f,
                Globals.TERRAIN_LAYER_MASK
                ))
            {
                _placedBuilding.SetPosition(_raycastHit.point);
                if (_lastPlacementPosition != _raycastHit.point)
                {
                    _placedBuilding.CheckValidPlacement();

                }
                _lastPlacementPosition = _raycastHit.point;

            }

            if (_placedBuilding.HasValidPlacement && Input.GetMouseButtonDown(0))
            {
                _PlacedBuilding();
            }


        }
    }

    void _PlacedBuilding()
    {
        _placedBuilding.Place();

        _PreparePlacedBuilding(_placedBuilding.DataIndex);

    }

    void _PreparePlacedBuilding(int buildingDataIndex)
    {
        if (_placedBuilding != null)
        {
            Destroy(_placedBuilding.Transform.gameObject);
        }
        Building building = new Building(

            Globals.BUILDING_DATA[buildingDataIndex]);

        building.Transform.GetComponent<Building_manager>().Initialize(building);

        _placedBuilding = building;

        _lastPlacementPosition = Vector3.zero;

        _placedBuilding.Place();

        _PreparePlacedBuilding(_placedBuilding.DataIndex);

    }

    void _CancelPlacedBuing()
    {
        Destroy(_placedBuilding.Transform.gameObject);
        _placedBuilding = null;

    }


}
