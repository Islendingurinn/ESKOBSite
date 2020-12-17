using ESKOBSite.Models;

namespace ESKOBSite.Viewmodel
{
    public class CreateViewmodel
    {
        public Tenant Tenant { get; set; }
        public Idea Idea { get; set; }
        public Manager LoggedIn { get; set; }
    }
}