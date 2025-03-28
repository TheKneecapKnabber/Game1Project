using AICore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using static UnityEngine.UI.GridLayoutGroup;

namespace BehaviorTree
{
    public class HasReachedDestAction : BTActionNodeBase
    {
        protected override void OnStart()
        {
           
        }
        protected override void OnStop()
        {
            
        }
        protected override State OnUpdate()
        {
            return _owner.HasReachedDest ? State.Success : State.Failure;
        }
    }
}
