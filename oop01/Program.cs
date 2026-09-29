using System.ComponentModel.DataAnnotations;
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

            #region Q2  a) Identify at least three problems with this design from an encapsulation perspective.
            //Public Fields, Lack of Data Validation ,Immutability
            #endregion

            #region Q2 b) How can private fields and public properties improve this design? 
            //Validation,Protection,Controlled Access Control
            #endregion
        }
    }
}
