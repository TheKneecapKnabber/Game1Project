using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	public class InverterNode : BTDecoratorNodeBase 
	{
        protected override void OnStart()
        {
          
        }
        protected override void OnStop()
        {
            
        }
        protected override State OnUpdate()
        {
            BTBaseNode Child = GetPort("exit").Connection.node as BTBaseNode;

            switch (Child.Update())
            {
                case State.Running:
                    state = State.Running;
                    break;
                case State.Success:
                    state = State.Success;
                    break;
                case State.Failure:
                    state = State.Failure;
                    break;
            }
            return state;
        }

    }
}
