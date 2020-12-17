using ESKOBSite.Models;

namespace ESKOBSite.Viewmodel
{
    public class IdeaViewmodel
    {
        public Idea Idea { get; set; }
        public Task Task { get; set; }
        public Tenant Tenant { get; set; }
        public Manager LoggedIn { get; set; }
    }
}