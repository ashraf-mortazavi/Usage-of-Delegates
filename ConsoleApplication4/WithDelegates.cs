using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{

    public enum Operation
    {
        Sum,
        Substract,
        Multiply
    }
    class WithDelegates
    {

        static void Main(string[] args)
        {

            var excutionmanager = new ExcutionManager();
            var opator = new OperationManager(20, 10, excutionmanager);
            var result = opator.Excute(Operation.Sum);
            Console.WriteLine($"The result of the operation WITH delegates in code: {result}");
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var opManager = new WithoutDelegates(20, 10);
            var result2 = opManager.Execute(Operation.Sum);
            Console.WriteLine($"The result of the operation WITHOUT delegates in code:{result}");
            Console.ReadKey();
        }

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

   
    }
}
