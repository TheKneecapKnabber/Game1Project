using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AICore;
using Unity.VisualScripting;
using UnityEngine.Windows;

namespace BehaviorTree
{
    public class BTAgent : AIAgentBase
    {
        [SerializeField] private BehaviorTreeGraph btGraph;
        [SerializeField] private Transform[] _waypoints;

        private Dictionary<string, object> _blackboard;

        public Dictionary<string, object> GetBlackboard;
        
       

        protected override void Start()
        {
            
            base.Start();

            _blackboard = new Dictionary<string, object>();
            _blackboard.Add("Waypoints", _waypoints);
            _blackboard.Add("WaypointIndex", 0);

            if (btGraph != null )
            {
                btGraph.InitBehaviortree(this);
            }
        }
        protected override void FixedUpdate()
        {
            AssessTargets();
            if (btGraph != null && btGraph.rootNode != null)
            {
                btGraph.Update();
            }

            base.FixedUpdate();
        }

    }

}
