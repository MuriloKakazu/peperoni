using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Strategies {
    public interface ISaveStrategy<T> where T : Entity {
        T Save(T entity);
    }
}
