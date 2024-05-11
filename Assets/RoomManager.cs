using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

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
                image.enabled = true;
            }
        }
    }
}
