using System;

namespace _01.RefactoringClass
{
    /// <summary>
    /// This class checks if given school class has a lesson at the time.
    /// I know InClass and Class shouldn't be in such a tight coupling,
    /// but refactoring it would proprably change the logic of the classes.
    /// </summary>
    public class InClass
    {
        public void IsInClass(bool inClass)
        {
            string result = inClass.ToString();
            Console.WriteLine(result);
        }
    }
}
