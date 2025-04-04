﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	public abstract class BTCompositeNodeBase : BTBaseNode 
	{
		[Input(connectionType = ConnectionType.Override)] public bool enter;
		[Output(dynamicPortList = true, connectionType = ConnectionType.Override)] public bool exit;

		protected int _portCount;

        public override void InitNode(BTAgent owner)
        {
            base.InitNode(owner);
            _portCount = -1;

            foreach(NodePort port in Outputs)
            {
                _portCount++;
            }
        }
    }
}
