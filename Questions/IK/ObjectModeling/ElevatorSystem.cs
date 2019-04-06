using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.ObjectModeling
{
    /// <summary>
    /// https://interview-kickstart.teachable.com/courses/353875/lectures/5437743
    /// </summary>
    class ElevatorSystem
    {

        
        public bool DispatchRequest(Request request)
        {
            // check available elevators
            // figure our which one can take the request
            // Queue the request to the elevator

            return false;
        }
    }

    class Request
    {
        public int Floor;
        public string ElevatorId;
        bool FromInside;

        public Request(int floor)
        {
            Floor = floor;
            ElevatorId = string.Empty;
            FromInside = false;
        }

        public Request(int floor, string elevatorId)
        {
            Floor = floor;
            ElevatorId = elevatorId;
            FromInside = true;
        }
    }

    enum ElevatorState
    {
        Operational,
        Maintenance
    }

    enum Direction
    {
        None,
        Up,
        Down
    }

    class Elevator
    {
        public string Id;
        public ElevatorState State;

        public Elevator(string id)
        {
            Id = id;
        }

        public Direction Direction;
        public bool IsMoving;
        public int LastFloor;

        public bool OpenDoor()
        {

        }

        public bool CloseDoor()
        {

        }
        
        public bool QueueRequest(Request request)
        {
            if (State == ElevatorState.Maintenance)
                return false;

            if (string.IsNullOrWhiteSpace(request.ElevatorId) && request.ElevatorId != this.Id)
                return false;

            if (LastFloor == request.Floor)
                return false;

            if (Direction == Direction.None)
            {
                // queue request and start moving
                if (LastFloor > request.Floor)
                {

                }
                else
                {

                }
            }
            else if (Direction == Direction.Up)
            {

            }
            else
            {

            }

            IsMoving = true;
        }
    }
}
