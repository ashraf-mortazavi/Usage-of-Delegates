using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{

    class WithoutDelegates
    {

        private int _first;
        private int _second;
        public WithoutDelegates(int first, int second)
        {
            _first = first;
            _second = second;
        }


        private int Sum()
        {
            return _first + _second;
        }

        private int Subtract()
        {
            return _first - _second;
        }

        private int Multiply()
        {
            return _first * _second;
        }


        public int Execute(Operation operation)
        {
            switch (operation)
            {
                case Operation.Sum:
                    return Sum();
                case Operation.Substract:
                    return Subtract();
                case Operation.Multiply:
                    return Multiply();
                default:
                    return -1;
            }
        }


    }

   



}
