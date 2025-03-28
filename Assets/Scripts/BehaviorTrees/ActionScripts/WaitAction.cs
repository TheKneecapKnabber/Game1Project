using AICore;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{
	public class WaitAction : BTActionNodeBase
    {
        public WaitType waitType;
        public Vector2 waitDuration;

        private float _value;
        private float _startTime; 

        public enum WaitType
        {
            SetDuration,
            RandomDuration
        }
        protected override void OnStart()
        {
            if(waitType == WaitType.SetDuration)
            {
                _value = waitDuration.x;
            }
            else
            {
                _value = Random.Range(waitDuration.x, waitDuration.y);
            }

            _startTime = Time.time;
        }

        protected override void OnStop()
        {
            
        }
        protected override State OnUpdate()
        {
            return (Time.time - _startTime) > _value ? State.Success : State.Running;
        }

    }
}
