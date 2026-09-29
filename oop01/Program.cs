using System.Numerics;

namespace oop01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1 a)  What happens when a DeliveryAddress variable is copied into another variable and the copy is modified? ,
            //a complete value copy of the struct instance is created
            //.Modifying the copied variable will not affect the original variable.
            #endregion

            #region Q1 b) What happens when a Customer variable is copied into another variable and one variable modifies the object?
            //a reference copy of the class instance is created
            //.Modifying the copied variable will affect the original variable.
            #endregion
        }
    }
}
