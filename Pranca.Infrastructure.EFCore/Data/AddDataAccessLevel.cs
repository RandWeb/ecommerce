using Framework.Infrastructure;
using Pranca.Domain.Users.AccessLevelAggregate.Entities;
using Pranca.Infrastructure.EFCore.Common.Extentions;
using Pranca.Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pranca.Infrastructure.EFCore.Data
{
    public class AddDataAccessLevel
    {
        BaseRepository<AccessLevel> _repAccessLevel;
        public AddDataAccessLevel()
        {
           _repAccessLevel = new BaseRepository<AccessLevel>(new DatabaseContext());
        }

        public void Run()
        {
            if (!_repAccessLevel.Get.Any(a => a.Name == "GeneralManager"))
            {
                _repAccessLevel.AddAsync(new AccessLevel()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "GeneralManager"
                }, default, false).Wait();
            }



            _repAccessLevel.SaveChangeAsync().Wait();
        }
    }
}
