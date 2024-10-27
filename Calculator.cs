using System;
using System.Data;


namespace Calculator
{
    public class Calculator
    {
        public static double Eval(string expression)
        {
            // compute a math expression
            DataTable table = new DataTable();

            return Convert.ToDouble(table.Compute(expression, string.Empty));
        }
    }
}