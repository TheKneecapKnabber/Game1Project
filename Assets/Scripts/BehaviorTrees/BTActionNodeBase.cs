using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	public abstract class BTActionNodeBase : BTBaseNode 
	{
		[Input(connectionType = ConnectionType.Override)] public bool enter;
		
	}
}
