using System.ComponentModel.DataAnnotations;

namespace WEB_API_Database_Connection
{
    public class Employe
    {
        [Key]
        public int Emp_ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string dept {  get; set; }
    }
}
