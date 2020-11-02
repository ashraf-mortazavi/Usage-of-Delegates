using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {

        public enum Operation
        {
            Sum,
            Substract,
            Multiply
        }


        //public class OperationManager
        //{
        //    private int _first;
        //    private int _second;
        //    public OperationManager( int first, int second)
        //    {
        //        _first = first;
        //        _second = second;
        //    }


        //    private int Sum ()
        //    {
        //        return _first + _second;
        //    }

        //    private int Subtract()
        //    {
        //        return _first - _second;
        //    }

        //    private int Multiply()
        //    {
        //        return _first * _second;
        //    }


        //    public int Execute (Operation operation)
        //    {
        //        switch (operation)
        //        {
        //            case Operation.Sum:
        //                return Sum();
        //            case Operation.Substract:
        //                return Subtract();
        //            case Operation.Multiply:
        //                return Multiply();
        //            default:
        //                return -1;
        //        }
        //    }
        //}

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="args"></param>

       public class ExcutionManager
        {
            public Dictionary<Operation, Func<int>> FuncExcute { get; set; }
            private Func<int> _sum;
            private Func<int> _substract;
            private Func<int> _multiply;


            public ExcutionManager ()
            {
                FuncExcute = new Dictionary<Operation, Func<int>>(3);
            }

            public void Populatefunction(Func<int> Sum, Func<int> Subtract, Func<int> Multiply)
            {
                _sum = Sum;
                _substract = Subtract;
                _multiply = Multiply;
            }

            public void PrepareExcution()
            {
                FuncExcute.Add(Operation.Sum, _sum);
                FuncExcute.Add(Operation.Multiply, _multiply);
                FuncExcute.Add(Operation.Substract, _substract);
            }

        }


        public class OperationManager
        {
            private int _first;
            private int _second;
            private readonly ExcutionManager _excutionmanager;
            public OperationManager(int first, int second, ExcutionManager excutionmanager)
            {
                _first = first;
                _second = second;
                _excutionmanager = excutionmanager;
                _excutionmanager.Populatefunction(Sum, Subtract, Multiply);
                _excutionmanager.PrepareExcution();

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

            public int Excute(Operation operation)
            {
                return _excutionmanager.FuncExcute.ContainsKey(operation) ? _excutionmanager.FuncExcute[operation]() : -1;

            }
         
        }

        static void Main(string[] args)
        {

            var excutionmanager = new ExcutionManager();
            var opator = new OperationManager(20, 10, excutionmanager);
            var result = opator.Excute(Operation.Sum);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
