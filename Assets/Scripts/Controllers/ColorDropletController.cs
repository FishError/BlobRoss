using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDropletController : MonoBehaviour
{
    public Color color;
    public ColorDropletData colorDropletData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            Equipment equipment;

            if (color == Color.Red)
            {
                // Get red equipment from player
                equipment = player.equipments[0];
                equipment.colorDropletStack++;
            }

            if (color == Color.Blue)
            {
                // Get blue equipment from player
                equipment = player.equipments[1];
                equipment.colorDropletStack++;
            }

            if (color == Color.Yellow)
            {
                // Get yellow equipment from player
                equipment = player.equipments[2];
                equipment.colorDropletStack++;
            }




        }
    }
}
