using System;
using UnityEngine;

namespace ComponentsModule
{
    public interface IWeapon
    {
        event Action<Transform> Used;
        event Action<Vector3, Vector3> Hit;

        void Use();
    }
}