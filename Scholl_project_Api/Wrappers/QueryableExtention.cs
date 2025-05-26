using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Scholl_project_Api.Wrappers
{
    public static class QueryableExtention
    {
        // Extension method to paginate IQueryable data
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source), "Source cannot be null");

            // Set default values if pageNumber or pageSize is 0
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;

            // Count the total number of items
            int totalItems = await source.AsNoTracking().CountAsync();

            // If there are no items, return an empty paginated result
            if (totalItems == 0)
                return new PaginatedResult<T>(new List<T>(), pageNumber, pageSize, totalItems)
                {
                    TotalPages = 0,
                    HasPreviousPage = false,
                    HasNextPage = false
                };

            // Calculate the total number of pages
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Adjust pageNumber if it exceeds totalPages
            pageNumber = pageNumber > totalPages ? totalPages : pageNumber;

            // Fetch the paginated data
            var data = await source.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            // Return the PaginatedResult
            return new PaginatedResult<T>(data, pageNumber, pageSize, totalItems)
            {
                TotalPages = totalPages,
                HasPreviousPage = pageNumber > 1,
                HasNextPage = pageNumber < totalPages
            };
        }
    }
}
