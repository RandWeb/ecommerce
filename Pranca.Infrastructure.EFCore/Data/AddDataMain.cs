using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Data
{
    public class AddDataMain
    {
        public void Run()
        {
            try
            {
                new AddDataAccessLevel().Run();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
