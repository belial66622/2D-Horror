using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private List<Room> roomList = new ();

    /// <summary>
    /// Menghilangkan renderer
    /// </summary>
    /// <param name="disableRoom">ruangan yang dihilangkan</param>
    /// <param name="nextRoom">ruangan tujuan yang akan dimunculkan</param>
    public void RoomDisable(Transform disableRoom, Transform nextRoom)
    { 
        EnableSprite(nextRoom);
        DisableSprite(disableRoom);
    }

    /// <summary>
    /// Menghilangkan renderer.
    /// </summary>
    /// <param name="disableRoom">ruangan yang dihilangkan</param>
    public void RoomDisable(Transform disableRoom)
    { 
        DisableSprite(disableRoom);
    }

    private void DisableSprite(Transform room)
    {
        for (int i = 0; i < room.childCount; i++)
        {
            if (room.GetChild(i).TryGetComponent<SpriteRenderer>(out SpriteRenderer image))
            {
                image.enabled = false;
            }
        }
    }
    private void EnableSprite(Transform room)
    {
        for (int i = 0; i < room.childCount; i++)
        {
            if (room.GetChild(i).TryGetComponent<SpriteRenderer>(out SpriteRenderer image))
            {
                if (image.gameObject.TryGetComponent<NoRender>(out _))
                {
                    continue;
                }
                    image.enabled = true;
            }
        }
    }

    public void AddRoom(Room room)
    {
        roomList.Add(room);
    }

    public Warp GetRoom(string location)
    {
        List<Warp> warplist = new();
        for (int i = 0; i < roomList.Count; i++)
        {
            if (location == roomList[i].RoomName)
            {
                warplist = roomList[i].getWarpToOther();
                break;
            }
        }

        return warplist[Random.Range(0, warplist.Count)];
    }
}
