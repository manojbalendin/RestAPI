using System;

namespace RestApi.Domain
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
