using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ray
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("One Handed Attack ANimations")]
        public string Light_Attack_1;
        public string Light_Attack_2;
        public string Heavy_Attack_1;

        [Header ("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;
    }
}