﻿using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public int PassengersCapacity { get; set; }

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.PassengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            PassengerPlane plane = obj as PassengerPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   this.PassengersCapacity == plane.PassengersCapacity;
        }

        public override int GetHashCode()
        {
            int hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PassengersCapacity.GetHashCode();
            return hashCode;
        }
       
        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", passengersCapacity=" + this.PassengersCapacity +
                    '}');
        }       
        
    }
}
