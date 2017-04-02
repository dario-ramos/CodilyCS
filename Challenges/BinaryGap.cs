using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    private enum State { SEEKING_FIRST_GAP, FOUND_FIRST_ONE, COUNTING_ZEROS };

    private State _state;
    private ulong _gapSize;
    private ulong _maxGapSize;

    public Solution()
    {
        _state = State.SEEKING_FIRST_GAP;
        _gapSize = 0;
        _maxGapSize = 0;
    }

    public int solution(int N)
    {
        for (int i = sizeof(int) * 8 - 1; i >= 0; i--)
        {
            //Console.Write("Position " + i + ": ");
            if ((N & (1 << i)) != 0)
            {
                //1
                //Console.WriteLine("1");
                HandleEvent(true);
            }
            else
            {
                //0
                //Console.WriteLine("0");
                HandleEvent(false);
            }
        }
        return (int)_maxGapSize;
    }

    private void HandleEvent(bool bit)
    {
        switch (_state)
        {
            case State.COUNTING_ZEROS:
                HandleEventInCountingZerosState(bit);
                break;
            case State.FOUND_FIRST_ONE:
                HandleEventInFoundFirstOneState(bit);
                break;
            case State.SEEKING_FIRST_GAP:
                HandleEventInSeekingGapState(bit);
                break;
        }
    }

    private void HandleEventInCountingZerosState(bool bit)
    {
        if (!bit)
        {
            _gapSize++;
            //Console.WriteLine("COUNTING_ZEROS: " + _gapSize);
        }
        else
        {
            //End of gap
            if (_gapSize > _maxGapSize)
            {
                _maxGapSize = _gapSize;
            }
            //Console.WriteLine("COUNTING_ZEROS -> FOUND_FIRST_ONE. END OF GAP! gapSize: " + _gapSize + ", max: " + _maxGapSize);
            _state = State.FOUND_FIRST_ONE; //A potential start of a new gap
        }
    }

    private void HandleEventInFoundFirstOneState(bool bit)
    {
        if (!bit)
        {
            _gapSize = 1;
            _state = State.COUNTING_ZEROS;
            //Console.WriteLine("FOUND_FIRST_ONE -> COUNTING_ZEROS");
        }
    }

    private void HandleEventInSeekingGapState(bool bit)
    {
        if (bit)
        {
            //Console.WriteLine("SEEKING_GAP -> FOUND_FIRST_ONE");
            _state = State.FOUND_FIRST_ONE;
        }
    }
}