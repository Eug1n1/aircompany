using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; private set; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<Plane> GetPlanesByType(Plane plane)
        {
            return Planes
                .FindAll(p => p.GetType() == plane.GetType());
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes
                .FindAll(p => p.GetType() == typeof(PassengerPlane))
                .Cast<PassengerPlane>()
                .ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes
                .FindAll(p => p.GetType() == typeof(MilitaryPlane))
                .Cast<MilitaryPlane>()
                .ToList(); ;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes()
                .OrderByDescending(p => p.PassengersCapacity)
                .First();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes()
                .FindAll(p => p.Type == MilitaryType.TRANSPORT)
                .ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(p => p.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(p => p.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(p => p.MaxLoadCapacity));
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.Model)) +
                    '}';
        }
    }
}
