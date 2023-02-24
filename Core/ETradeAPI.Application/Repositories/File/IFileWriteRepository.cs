using ETradeAPI.Application.Repositories.Design;
using F = ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories.File
{
    public interface IFileWriteRepository : IWriteRepository<F::File>
    {
    }
}
