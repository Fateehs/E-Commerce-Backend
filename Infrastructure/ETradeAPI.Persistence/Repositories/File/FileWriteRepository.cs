using ETradeAPI.Application.Repositories.Design;
using ETradeAPI.Application.Repositories.File;
using ETradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<ETradeAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
