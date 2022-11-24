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

            if(color == Color.White)
            {
                // Heal player
                player.ModifyHealthPoints(colorDropletData.healPoints);
            }

            if (color == Color.Red)
            {
                // Get red equipment from player
                RedEquipment redEquipment = ((RedEquipment)player.equipments[0]);

                // Increment color droplet stack counter
                redEquipment.colorDropletStack++;
                if (redEquipment.colorDropletStack == 0) return;

                // Upgrade damage
                redEquipment.damage += colorDropletData.damageUpgrade;

                // Upgrade attack speed
                redEquipment.attackSpeed += colorDropletData.attackSpeedUpgrade;

                // Set upgrade
                redEquipment.setUpgrade();
            }

            if (color == Color.Blue)
            {
                // Get blue equipment from player
                BlueEquipment blueEquipment = ((BlueEquipment)player.equipments[1]);

                // Increment color droplet stack counter
                blueEquipment.colorDropletStack++;
                if (blueEquipment.colorDropletStack == 0) return;

                // Upgrade durability
                blueEquipment.Durability += colorDropletData.durabilityUpgrade;

                // Upgrade duration
                blueEquipment.Duration += colorDropletData.durationUpgrade;

                // Set upgrade
                blueEquipment.setUpgrade();
            }

            if (color == Color.Yellow)
            {
                // Get yellow equipment from player
                YellowEquipment yellowEquipment = ((YellowEquipment)player.equipments[2]);

                // Increment color droplet stack counter
                yellowEquipment.colorDropletStack++;
                if (yellowEquipment.colorDropletStack == 0) return;

                // Upgrade cooldown
                yellowEquipment.Cooldown += colorDropletData.cooldownUpgrade;

            }

            Destroy(gameObject);

            
            




        }
    }
}