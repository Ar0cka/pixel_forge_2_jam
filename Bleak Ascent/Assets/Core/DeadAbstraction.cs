using System;
using UnityEngine;

namespace Core
{
    public abstract class DeadAbstraction : MonoBehaviour
    {
        public Action OnDie;
        public abstract void Die();
    }
}