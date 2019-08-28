//https://www.reddit.com/r/dailyprogrammer/comments/1v4cjd/011314_challenge_148_easy_combination_lock/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationLockProblem
{

    public class CombinationLock
    {
        private int _clicks;

        public int Clicks
        {
            get { return _clicks; }
        }

        private bool TurnRightNext { get; set; }

        private int WheelPosition { get; set; }

        private int MaxWheel { get; set; }

        private int[] Sequence { get; set; }


        public CombinationLock(int Wheelsize, int[] _sequence)
        {
            TurnRightNext = true;
            _clicks = 0;
            Sequence = _sequence;
            MaxWheel = Wheelsize - 1;
            Reset(Wheelsize);
        }

        public void Reset(int _wheelsize)
        {
            _clicks = _wheelsize * 2;
            TurnRightNext = true;

        }

        public void TurnSequence()
        {
            for (int i = 0; i < Sequence.Length; i++)
            {
                while (Sequence[i] != WheelPosition)
                {
                    if (TurnRightNext)
                    {
                        TurnRight();
                        _clicks++;
                    }
                    else
                    {
                        TurnLeft();
                        _clicks++;
                    }
                }

                TurnRightNext = TurnRightNext ? false : true;
            }
        }


        private void TurnRight()
        {
            WheelPosition = WheelPosition == MaxWheel ? 0 : WheelPosition + 1;
        }
        private void TurnLeft()
        {
            WheelPosition = WheelPosition == 0 ? MaxWheel : WheelPosition - 1;
        }



    }

}
