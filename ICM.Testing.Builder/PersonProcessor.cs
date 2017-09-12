using System;
using System.Linq;

namespace ICM.Testing.Builder
{
    public class PersonProcessor
    {

        public void ProcessEntity(Person e)
        {
            ProcessTags(e);
        }

        private static void ProcessTags(Person e)
        {
            if (e.Name.Length > 10)
                e.Tag("LongName");

            // vuile impl  
            var age = DateTime.Now.Year - e.BirthDate.Year;

            if (age > 18) e.Tag("Volwassen");
            if (age > 65) e.Tag("Pensioen");

            if (e.Children.Any())
            {
                e.Tag("Heeft kinderen");

                switch (e.Children.Count)
                {
                    case 1:
                        e.Tag("1 kind");
                        break;
                    case 2:
                        e.Tag("2 kinderen");
                        break;
                    default:
                        e.Tag("Veel kinderen");
                        break;
                }
            }

            if (e.Parent != null)
            {
                e.Tag("Ouder gekend");

                if (e.Parent.Children.Count == 1)
                {
                    e.Tag("Enig kind");
                }
            }
        }
    }
}
