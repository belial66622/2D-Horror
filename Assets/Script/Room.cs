using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomManager _manager;
    [SerializeField]
    private bool defaultRoom = false;

    private List <Warp> _warpLocation = new List<Warp>();

    [field: SerializeField]
    public string RoomName { get; private set; }


    private void Awake()
    {
        _manager= GetComponentInParent<RoomManager>();
        if (!defaultRoom)
        {
            _manager.RoomDisable(transform);
        }
        _manager.AddRoom(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom(Transform nextRoom)
    {
        _manager.RoomDisable(transform, nextRoom);
    }

    public void AddWarpLocation(Warp location)
    {
        _warpLocation.Add(location);
    }


    public List<Warp>getWarpToOther()
    {
        return _warpLocation ;
    }
}
