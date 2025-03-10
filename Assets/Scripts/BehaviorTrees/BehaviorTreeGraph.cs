using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	[CreateAssetMenu]
	public class BehaviorTreeGraph : NodeGraph 
	{
		private BTBaseNode _rootNode;
		private State _curState;

		public BTBaseNode rootNode
		{  
			get 
			{ 
				if (_rootNode == null)
				{
					FindRootNode();
				}
				return _rootNode;
			}
			set
			{
				_rootNode = value;
			}
		}

		public void FindRootNode()
		{
			foreach (Node node in nodes)
			{
				if (node is RootNode)
				{
					_rootNode = node as RootNode;
					return;
				}
			}
		}
		public void initNodes()
		{
			//
		}
	}
}
