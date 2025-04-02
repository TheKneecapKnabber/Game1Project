/*using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	public class MoveToCurrTargetAction : BTActionNodeBase
	{
        protected override void OnStart()
        {
        }
        protected override void OnStop()
        {
        }
        protected override State OnUpdate()
        {
            if (!_owner.GetNavAgent.pathPending)
            {
                _owner.GetNavAgent.SetDestination(_owner.GetCurrTarget.GetPosition);
            }
            else
            {
                return State.Running;
            }

            return State.Success;
        }

    }
}
*/