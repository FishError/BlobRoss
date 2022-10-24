using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteEffect : MonoBehaviour
{
    public EquipmentData equipmentData;

    private void Update()
    {
        StartCoroutine(ShieldDuration());
    }

    IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(equipmentData.duration);
        this.gameObject.SetActive(false);
    }

}
