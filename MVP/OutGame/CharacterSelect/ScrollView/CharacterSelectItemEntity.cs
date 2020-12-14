using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo5GunGame.Entity
{
    public class CharacterSelectItemEntity
    {
        public string Message { get; }

        public CharacterSelectItemEntity(string mes)
        {
            Message = mes;
        }
    }
}