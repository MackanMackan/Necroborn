using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Summon
{
    public interface ICommand
    {
        public void Initialize(Transform target, NavMeshAgent agent, AIAnimationController animationController, Transform self);
        public void Execute();
        public void Uninitialize();
    }
}
