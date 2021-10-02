using System;
using System.Collections.Generic;
using System.Linq;
namespace RobotWorld
{
    internal class Robot
    {
        private List<string> flatware;
        private readonly IKnowledge knowledge;

        public Robot(IKnowledge knowledge)
        {
            this.flatware = new List<string>();
            this.knowledge = knowledge;
        }

        internal bool Eat(string food)
        {
            string flatwareToEat = chooseFlatware(food);
            if (flatwareToEat != null)
            {
                flatware.Remove(flatwareToEat);
                return true;
            }
            return false;
        }

        internal void addFlatware(string flatware)
        {
            this.flatware.Add(flatware);
        }
        private string chooseFlatware(string food)
        {
            string requiredFlatware = knowledge.getRequiredFlatware(food);
            List<string> list = requiredFlatware!= null ? requiredFlatware.Split(';').ToList() : new List<string>();
            if (this.flatware.Count > 0 && requiredFlatware != null)
            {
                return this.flatware.First(it => requiredFlatware.Contains(it));
            }
            return null;
        }
    }
}