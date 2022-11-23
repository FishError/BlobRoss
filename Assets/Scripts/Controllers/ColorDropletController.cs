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

            if (color == Color.Red)
            {
                // Get red equipment from player
                RedEquipment redEquipment = ((RedEquipment)player.equipments[0]);
                redEquipment.colorDropletStack++;
                if (redEquipment.colorDropletStack == 0) return;

                // Upgrade damage
                redEquipment.damage += colorDropletData.damageUpgrade;

                // Upgrade attack speed
                redEquipment.attackSpeed += colorDropletData.attackSpeedUpgrade;

                redEquipment.setUpgrade();
            }

            if (color == Color.Blue)
            {
                // Get blue equipment from player
                equipment = player.equipments[1];
                equipment.colorDropletStack++;
            }


            Destroy(gameObject);

            
            //if (color == Color.Yellow)
            //{
            //    // Get yellow equipment from player
            //    equipment = player.equipments[2];
            //    equipment.colorDropletStack++;
            //}




        }
    }
}
