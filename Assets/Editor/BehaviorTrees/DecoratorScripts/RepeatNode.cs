/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	public class RepeatNode : BTDecoratorNodeBase 
	{
        protected override void OnStart()
        {
            throw new System.NotImplementedException();
        }
        protected override void OnStop()
        {
            throw new System.NotImplementedException();
        }
        protected override State OnUpdate()
        {
            BTBaseNode child = GetPort("exit").Connection.node as BTBaseNode;
            child.Update();
            return State.Running;
            
        }

    }
}
*/