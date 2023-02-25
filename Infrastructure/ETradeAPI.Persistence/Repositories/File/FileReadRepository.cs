using ETradeAPI.Application.Repositories.File;
using ETradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<ETradeAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
