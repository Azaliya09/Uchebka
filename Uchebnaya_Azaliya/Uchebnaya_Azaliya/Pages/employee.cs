using Uchebnaya_Azaliya.Base;

namespace Uchebnaya_Azaliya.Pages
{
    internal class employee : Employee
    {
        public int Id_Employee { get; set; }
        public string Surname { get; set; }
        public int? Id_Position { get; set; }
        public decimal? Salary { get; set; }
    }
}