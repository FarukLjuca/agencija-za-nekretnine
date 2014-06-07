using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM.DAO
{
    public interface IDaoCrud<T>
    {
        long Create(T Entity);
        T Read(T Entity);
        T Update(T Entity);
        void Delete(T Entity);
    }
}
