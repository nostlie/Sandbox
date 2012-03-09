using MvcNinject.Models;

namespace MvcNinject.Repositories
{
    public class BlahRepository : IBlahRepository
    {
        /*
         * This is where any data calls happen to EntityFramework, web services, etc. 
         * It helps to separate persistence logic from the business logic and UI
         */

        public BlahModel GetBlahTrue()
        {
            return new BlahModel 
            { 
                BlahId = 1, 
                BlahMessage = "Hello? Yes this is Blah. True.", 
                BlahAboutTitle = "About Blah Title", 
                BlahAboutBody = "This is all about Blah. He is a blahdity blah kind of guy" 
            };
        }

        public BlahModel GetBlahFalse()
        {
            return new BlahModel
            {
                BlahId = 1,
                BlahMessage = "Hello? Yes this is Blah. False.",
                BlahAboutTitle = "About Blah Title",
                BlahAboutBody = "This is all about Blah. He is a blahdity blah kind of guy"
            };
        }

        public BlahModel[] GetAllBlahs()
        {
            return new[]
            {
                new BlahModel 
                {
                    BlahId = 1,
                    BlahMessage = "Hello? Yes this is Blah1. False.",
                    BlahAboutTitle = "About Blah1 Title",
                    BlahAboutBody = "This is all about Blah1. He is a blahdity blah kind of guy"
                },
                new BlahModel 
                {
                    BlahId = 2,
                    BlahMessage = "Hello? Yes this is Blah2. False.",
                    BlahAboutTitle = "About Blah2 Title",
                    BlahAboutBody = "This is all about Blah2. He is a blahdity blah kind of guy"
                }
            };
        }
    }
}
