using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Patterns
{
    interface RingState
    {
        void Ring();
        RingState VolumeUp();
        RingState VolumeDown();
    }

    class SilentState : RingState
    {
        public void Ring()
        {
            Console.WriteLine("...");
        }

        public RingState VolumeDown()
        {
            return this;
        }

        public RingState VolumeUp()
        {
            return new VibrateState();
        }
    }

    class VibrateState : RingState
    {
        public void Ring()
        {
            Console.WriteLine("Vibrating...");
        }

        public RingState VolumeDown()
        {
            return new SilentState();
        }

        public RingState VolumeUp()
        {
            return new SoundState();
        }
    }


    class SoundState : RingState
    {
        public void Ring()
        {
            Console.WriteLine("Ringing...");
        }

        public RingState VolumeDown()
        {
            return new VibrateState();
        }

        public RingState VolumeUp()
        {
            return this;
        }
    }

    class Phone
    {
        private RingState s = new SoundState();

        public void Ring()
        {
            s.Ring();
        }

        public void VolumeUp()
        {
            s = s.VolumeUp();
        }

        public void VolumeDown()
        {
            s = s.VolumeDown();
        }
    }


    class State
    {
        static void main()
        {
            Phone ph = new Phone();
            ph.Ring();

            ph.VolumeDown();
            ph.Ring();
            ph.VolumeDown();
            ph.Ring();

            ph.VolumeUp();
            ph.Ring();
            ph.VolumeUp();
            ph.Ring();
        }
    }
}
