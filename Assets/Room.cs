using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomManager _manager;
    [SerializeField]
    private bool defaultRoom = false;

    private void Awake()
    {
        _manager= GetComponentInParent<RoomManager>();
        if (!defaultRoom)
        {
            _manager.RoomDisable(transform);
        }
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
}
