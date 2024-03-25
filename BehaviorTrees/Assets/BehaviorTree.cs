using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
	class Task
	{
		// Return on success (true) or failure (false).
		public virtual bool run()
		{
			return false;
		}
	}

	class Selector : Task
	{
		Task[] children;

        public override bool run()
        {
            foreach (Task c in children)
			{
				if (c.run()) return true;
			}
			return false;
        }
    }
	
	class Sequence : Task
	{
		Task[] children;

        public override bool run()
        {
            foreach (Task c in children)
			{
				if (!c.run()) return false;
			}
			return true;
        }
    }
}
