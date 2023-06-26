using App.Contracts;
using App.Domain.IRepositories;
using App.Persistence.Context;
using App.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class FinanceRequestRepository : IFinanceRequestRepository
    {
       private readonly TaskContext _context;
        public FinanceRequestRepository(TaskContext context)
        {
             _context = context;
        }

        public async Task<PagedEntity<FinanceRequestDto>> GetFilterFinanceRequestDtoData(PagationFilter filter)
        {

            var query = _context.FinanceRequests
                  .AsQueryable();

            if (filter.Columns != null)
            {
                foreach (var entityfilter in filter.Columns)
                {
                    if (entityfilter.Name == "RequestNumber")
                    {
                        if (!string.IsNullOrEmpty(entityfilter.Value))
                        {
                            if (entityfilter.MatchMode == "startsWith")
                                query = query.Where(c => c.RequestNumber.ToString().StartsWith(entityfilter.Value));
                            else if (entityfilter.MatchMode == "contains")
                                query = query.Where(c => c.RequestNumber.ToString().Contains(entityfilter.Value));
                            else if (entityfilter.MatchMode == "notContains")
                                query = query.Where(c => !c.RequestNumber.ToString().Contains(entityfilter.Value));
                            else if (entityfilter.MatchMode == "endsWith")
                                query = query.Where(c => c.RequestNumber.ToString().EndsWith(entityfilter.Value));
                            else if (entityfilter.MatchMode == "equals")
                                query = query.Where(c => c.RequestNumber.ToString().Equals(entityfilter.Value));
                            else if (entityfilter.MatchMode == "notEquals")
                                query = query.Where(c => !c.RequestNumber.ToString().Equals(entityfilter.Value));
                        }
                    }
                    else if (entityfilter.Name == "status ")
                    {
                        if (!string.IsNullOrEmpty(entityfilter.Value))
                        {
                            if (entityfilter.MatchMode == "startsWith")
                                query = query.Where(c => c.RequestStatus.ToString().StartsWith(entityfilter.Value));
                            else if (entityfilter.MatchMode == "contains")
                                query = query.Where(c => c.RequestStatus.ToString().Contains(entityfilter.Value));
                            else if (entityfilter.MatchMode == "notContains")
                                query = query.Where(c => !c.RequestStatus.ToString().Contains(entityfilter.Value));
                            else if (entityfilter.MatchMode == "endsWith")
                                query = query.Where(c => c.RequestStatus.ToString().EndsWith(entityfilter.Value));
                            else if (entityfilter.MatchMode == "equals")
                                query = query.Where(c => c.RequestStatus.ToString().Equals(entityfilter.Value));
                            else if (entityfilter.MatchMode == "notEquals")
                                query = query.Where(c => !c.RequestStatus.ToString().Equals(entityfilter.Value));
                        }
                    }
                }
            }
            if (filter.SortOrder == -1)
            {

                if (filter.SortField == "RequestNumber")
                    query = query.OrderByDescending(c => c.RequestNumber);
                else if (filter.SortField == "RequestStatus")
                    query = query.OrderByDescending(c => c.RequestStatus);
                else if (filter.SortField == "PaymentAmount")
                    query = query.OrderByDescending(c => c.PaymentAmount);
                else if (filter.SortField == "PaymentPeriod")
                    query = query.OrderByDescending(c => c.PaymentPeriod);
                else if (filter.SortField == "TotalProfit")
                    query = query.OrderByDescending(c => c.TotalProfit);
            }
            else
            {

                if (filter.SortField == "RequestNumber")
                    query = query.OrderBy(c => c.RequestNumber);
                else if (filter.SortField == "RequestStatus")
                    query = query.OrderBy(c => c.RequestStatus);
                else if (filter.SortField == "PaymentAmount")
                    query = query.OrderBy(c => c.PaymentAmount);
                else if (filter.SortField == "PaymentPeriod")
                    query = query.OrderBy(c => c.PaymentPeriod);
                else if (filter.SortField == "TotalProfit")
                    query = query.OrderBy(c => c.TotalProfit);
            }

            var totalItemsCount = query.Count();

            var res = await query.
                Skip(filter.Start).
                Take(filter.Rows).
                AsNoTracking().
                Select(c => new FinanceRequestDto
                {
                    TotalProfit = c.TotalProfit,
                    PaymentAmount = c.PaymentAmount,
                    PaymentPeriod = c.PaymentPeriod,
                    RequestStatus = c.RequestStatus,
                    RequestNumber = c.RequestNumber
                }).ToListAsync();


            return new PagedEntity<FinanceRequestDto>(res, totalItemsCount);
        }

    }
}
