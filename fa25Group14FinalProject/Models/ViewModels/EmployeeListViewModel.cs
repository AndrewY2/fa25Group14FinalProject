using System;

namespace fa25Group14FinalProject.ViewModels
{
    public class EmployeeListViewModel
    {
        public String Id { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String Email { get; set; }
        public String PhoneNumber { get; set; }

        public Boolean IsActive { get; set; }

        // For showing / toggling Admin role
        public Boolean IsAdmin { get; set; }
    }
}
