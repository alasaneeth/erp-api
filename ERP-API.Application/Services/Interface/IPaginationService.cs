using ERP_API.Application.InputModel;
using ERP_API.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Application.Services.Interface
{
    public interface IPaginationService<T,S> where T : class
    {
        PaginationVM<T> GetPagination(List<S> source, PaginationInputModel pagination);
    }
}
